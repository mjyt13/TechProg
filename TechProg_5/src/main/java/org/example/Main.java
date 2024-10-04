package org.example;
import java.lang.*;
import java.util.*;
import java.io.*;
// В классе Main только происходит парсинг
public class Main {
    public static void main(String[] args) throws FileNotFoundException {
        Parser parser = new Parser();
        parser.XMLparse("D:\\random_structure_17.xml");
    }
}

class Parser {
    // Так как Книга (и все её атрибуты) находятся отдельно, а Библиотека - коллекция книг, в классе для парсинга есть только метод,
    // позволяющий разобрать XML
    public List<Book> XMLparse(String FilePath) throws FileNotFoundException {
        List<Book> library = new ArrayList<>();
//      Конструкция try-catch предполаает наличие исключений при работе с файлми
        try {
//          Инициализируются переменные как объекты классов для чтения из файла
            FileReader fileReader = new FileReader(FilePath);
            BufferedReader br = new BufferedReader(fileReader);
            String row;
//          Создаётся "пустой" объект класса Book для того, чтобы к нему был доступ в большой конструкции if else
            Book book = null;
            while ((row = br.readLine()) != null) {
//              Для чтения по строкам сочетание закрывающейся и открывающей треугольных скобок добавляет символ
//              перехода на новую строку, с помощью которого и происходит разделение
                String[] lines = (row.replaceAll("><", ">\n<")).split("\n");
                for (String line : lines) {
//                  Создать новый объект класса Book
                    if (line.startsWith("<book")) {
                        book = new Book();
//                      И присвоить полю id соответсвующее числовое значение
                        book.id = Integer.parseInt(line.substring(10, line.length() - 2));
                        System.out.println(book.id);
//                  Для всех полей класса книга выполняется одна процедура - занесение в строку подстроки между
//                  названиями атрибута и при необходимости приведение к необходимому типу
                    } else if (line.startsWith("<title>")) {
                        book.title = line.substring("<title>".length(), line.length() - "</title>".length());
                        System.out.println(book.title);
                    } else if (line.startsWith("<author>")) {
                        book.author = line.substring("<author>".length(), line.length() - "</author>".length());
                    } else if (line.startsWith("<year>")) {
                        book.year = Integer.parseInt(line.substring("<year>".length(), line.length() - "</year>".length()));
                    } else if (line.startsWith("<genre>")) {
                        book.genre = line.substring("<genre>".length(), line.length() - "</genre>".length());
//                  У книги есть цена с указанием валюты, для реализации используется класс Цена с полями валюта и значение
                    } else if (line.startsWith("<price")) {
                        book.price.currency = line.substring("<price currency=".length() + 1, "<price currency=".length() + 4);
                        book.price.value = Double.parseDouble(line.substring("<price currency=".length() + 6, line.length() - "</price>".length()));
                    } else if (line.startsWith("<format>")){
                        book.format = line.substring("<format>".length(),line.length()-"</format>".length());
//                  В книге есть объект класса Издатель, где имя его - поле
                    } else if (line.startsWith("<name>")) {
                        book.publisher.name = line.substring("<name>".length(), line.length() - "</name>".length());
//                  У класса издатель есть объект класса адрес, где поля - город и страна - вносятся по правилам
                    } else if (line.startsWith("<city>")) {
                        book.publisher.address.city = line.substring("<city>".length(), line.length() - "</city>".length());
                    } else if (line.startsWith("<country>")) {
                        book.publisher.address.Country = line.substring("<country>".length(), line.length() - "</country>".length());
                    } else if (line.startsWith("<translator>")) {
                        book.translator = line.substring("<translator>".length(), line.length() - "</translator>".length());
//                  Наград может быть несколько, поэтому они вносятся в список наград
                    } else if (line.startsWith("<award>")){
                        book.awards.add(line.substring("<award>".length(), line.length() - "</award>".length()));
                    }
//                  При достижении этой строки в XML заканчивается описание книги, тогда её можно добавить в библиотеку
                    if (line.equals("</book>")){
                        library.add(book);
                        book = null;
                    }
                }
//              Здесь проверяется наличие различных атрибутов (например, формата) у составленных классов
                for(Book book1 : library){
                    System.out.println(book1.format);
                }
            }
        } catch (IOException ex) {
            System.out.println(ex);
        }


        return library;
    }
}

class Book {
    int id;
    String title;
    String author;
    int year;
    String genre;
    Price price;
    String format;
    Publisher publisher;
    String translator;
    List<String> awards;

    public Book() {
        id = 0;
        title = null;
        author = null;
        year = 1970;
        genre = null;
        price = new Price();
        format = null;
        publisher = new Publisher();
        translator = null;
        awards = new ArrayList<>();
    }
}

class Price {
    String currency;
    double value;

    public Price() {
        currency = null;
        value = 0;
    }
}

class Publisher {
    String name;
    Address address;

    public Publisher() {
        name = null;
        address = new Address();
    }
}

class Address {
    String city;
    String Country;

    public Address() {
        city = null;
        Country = null;
    }
}