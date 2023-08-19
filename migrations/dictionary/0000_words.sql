--liquibase formatted sql

--changeset nboobekov:10
create table dictionary.words
(
    id      bigserial    not null,
    russian varchar(255) not null,
    english varchar(255) not null
);
--rollback drop table dictionary.words;