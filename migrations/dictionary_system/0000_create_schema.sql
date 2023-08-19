--liquibase formatted sql

--changeset nboobekov:10
create schema dictionary;
--rollback drop schema dictionary cascade;