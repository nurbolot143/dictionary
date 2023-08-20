--liquibase formatted sql

--changeset nboobekov:10
create table dictionary_system.words
(
    id      bigserial    not null,
    russian varchar(255) not null,
    english varchar(255) not null,

    constraint pk_words primary key (id)
);
--rollback drop table dictionary_system.words;