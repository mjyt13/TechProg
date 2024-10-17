package org.example;
import java.lang.*;
import java.util.*;
import java.io.*;
// В классе Main только происходит парсинг
public class Main {
    public static void main(String[] args) throws IOException {
        Parser parser = new Parser();
        parser.XMLparse("D:\\random_structure_17.xml");
    }
}

class Parser {
    // Так как Книга (и все её атрибуты) находятся отдельно, а Библиотека - коллекция книг, в классе для парсинга есть только метод,
    // позволяющий разобрать XML
    public List<Book> XMLparse(String FilePath) throws IOException {
        List<Book> library = new ArrayList<>();
//      Конструкция try-catch предполаает наличие исключений при работе с файлми
//          Инициализируются переменные как объекты классов для чтения из файла
            FileReader fileReader = new FileReader(FilePath);
            BufferedReader br = new BufferedReader(fileReader);
            String row;
//          Создаётся "пустой" объект класса Book для того, чтобы к нему был доступ в большой конструкции if else
            Book book = null;
            Publisher publisher = null;
            Address address = null;
            Price price = null;
            while ((row = br.readLine()) != null) {
//              Для чтения по строкам сочетание закрывающейся и открывающей треугольных скобок добавляет символ
//              перехода на новую строку, с помощью которого и происходит разделение
                String[] lines = (row.replaceAll("><", ">\n<")).split("\n");
                for (String line : lines) {
//                  Создать новый объект класса Book
                    if (line.startsWith("<book")) {
                        book = new Book();
//                      И присвоить полю id соответсвующее числовое значение
                        book.setId(Integer.parseInt(line.substring(10, line.length() - 2)));
                        System.out.println(book.getId());
//                  Для всех полей класса книга выполняется одна процедура - занесение в строку подстроки между
//                  названиями атрибута и при необходимости приведение к необходимому типу
                    } else if (line.startsWith("<title>")) {
                        book.setTitle(line.substring("<title>".length(), line.length() - "</title>".length()));
                    } else if (line.startsWith("<author>")) {
                        book.setAuthor(line.substring("<author>".length(), line.length() - "</author>".length()));
                    } else if (line.startsWith("<year>")) {
                        book.setYear(Integer.parseInt(line.substring("<year>".length(), line.length() - "</year>".length())));
                    } else if (line.startsWith("<genre>")) {
                        book.setGenre(line.substring("<genre>".length(), line.length() - "</genre>".length()));
//                  У книги есть цена с указанием валюты, для реализации используется класс Цена с полями валюта и значение
                    } else if (line.startsWith("<price")) {
                        price = new Price();
                        price.setCurrency(line.substring("<price currency=".length() + 1, "<price currency=".length() + 4));
                        price.setValue(Double.parseDouble(line.substring("<price currency=".length() + 6, line.length() - "</price>".length())));
                        book.setPrice(price);
                        price = null;
                    } else if (line.startsWith("<format>")){
                        book.setFormat(line.substring("<format>".length(),line.length()-"</format>".length()));
                    } else if (line.startsWith("<publisher>")) {
                        publisher = new Publisher();
                    } else if (line.startsWith("</publisher>")) {
                        book.setPublisher(publisher);
                        publisher = null;
                    } else if (line.startsWith("<name>")) {
                        publisher.setName(line.substring("<name>".length(), line.length() - "</name>".length()));
                    } else if (line.startsWith("<address>")) {
                        address = new Address();
                    }else if (line.startsWith("</address>")){
                        publisher.setAddress(address);
                        address = null;
                    }
                    else if (line.startsWith("<city>")) {
                        address.setCity(line.substring("<city>".length(), line.length() - "</city>".length()));
                    } else if (line.startsWith("<country>")) {
                        address.setCountry(line.substring("<country>".length(), line.length() - "</country>".length()));
                    } else if (line.startsWith("<translator>")) {
                        book.setTranslator(line.substring("<translator>".length(), line.length() - "</translator>".length()));
                    } else if (line.startsWith("<awards>")) {
                        book.newAwards();
                    } else if (line.startsWith("<award>")){
                        book.setAward(line.substring("<award>".length(), line.length() - "</award>".length()));
                    }
                    if (line.equals("</book>")){
                        library.add(book);
                        book = null;
                    }
                }
                for(Book book1 : library){
                    book1.PrintAll();
                }
            }
        return library;
    }
}

class Book {
    private int id;
    public void setId(int id){
        this.id = id;
    }
    public int getId(){
        return id;
    }
    private String title;
    public void setTitle(String title){
        this.title = title;
    }
    public String getTitle(){
        return title;
    }
    private String author;
    public void setAuthor(String author){
        this.author = author;
    }
    public String getAuthor(){
        return author;
    }
    private int year;
    public void setYear(int year){this.year = year;}
    public int getYear(){return year;}
    private String genre;
    public void setGenre(String genre){this.genre = genre;}
    public String getGenre(){return genre;}
    private Price price;
    public void setPrice(Price price){this.price = price;}
    public Price getPrice(){return price;}
    private String format;
    public void setFormat(String format){this.format = format;}
    public String getFormat(){return format;}
    private Publisher publisher;
    public void setPublisher(Publisher publisher){
        this.publisher = publisher;
    }
    public Publisher getPublisher() {
        return publisher;
    }
    private String translator;
    public void setTranslator(String translator){this.translator = translator;}
    public String getTranslator(){return translator;}
    private List<String> awards;
    public void newAwards(){
        this.awards = new ArrayList<>();
    }
    public void setAward(String award){awards.add(award);}
    public String getAward(int index){return awards.get(index);}
    public List<String> getAwards(){return awards;}
    public void PrintAll(){
        System.out.println(getId());
        System.out.println(getTitle());
        System.out.println(getAuthor());
        System.out.println(getFormat());
        System.out.println(getGenre());
        price.printAll();
        publisher.printAll();
        System.out.println(getTranslator());
        System.out.println(getYear());
        if (awards!=null) {
            for (String award : awards) {
                System.out.println(award);
            }
        }
    }
}

class Price {
    private String currency;
    public void setCurrency(String currency){this.currency = currency;}
    public String getCurrency(){return currency;}
    private double value;
    public void setValue(double value){this.value = value;}
    public double getValue(){return value;}
    public void printAll(){
        System.out.println(getValue());
        System.out.println(getCurrency());
    }
}

class Publisher {
    private String name;
    public void setName(String name){this.name = name;}
    public String getName(){return name;}
    private Address address;
    public void setAddress(Address address){this.address = address;}
    public Address getAddress(){return address;}
    public void printAll(){
        System.out.println(getName());
        address.printAll();
    }
}

class Address {
    private String city;
    public void setCity(String city){this.city = city;}
    public String getCity(){return city;}
    private String country;
    public void setCountry(String country){this.country = country;}
    public String getCountry(){return country;}
    public void printAll(){
        System.out.println(getCity());
        System.out.println(getCountry());
    }
}
