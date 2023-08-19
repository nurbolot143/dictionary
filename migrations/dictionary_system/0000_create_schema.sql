--liquibase formatted sql

--changeset nboobekov:10
create schema dictionary_system;
--rollback drop schema dictionary_system cascade;