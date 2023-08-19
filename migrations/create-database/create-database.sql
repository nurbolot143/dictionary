create user dictionary with password '123';

create database dictionary_db with owner dictionary;

\connect dictionary_db;
create schema liquibase authorization dictionary;