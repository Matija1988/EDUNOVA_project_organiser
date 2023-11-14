use master;
go
drop database EUprojectsAPP;
go
create database EUprojectsApp;
go
use EUprojectsApp;

create table EUprojects (
id int not null primary key identity (1,1), 
uniqueIDnumber varchar(50) not null, -- identifikacijska sifra projekta npr. K.K. 1012
name varchar(50) not null, -- puni naziv projekta
dateStart datetime,  
dateEnd datetime, 
isFinished bit,

);

create table teams(
team int not null, 
teamName varchar(50) not null, -- po projektu npr. Tim - Urbana aglomeracija Osijek ili RCK VirtuOS
member int not null,  
EUproject int not null,
activity int not null
);

create table members(
id int not null primary key identity(1,1),
name varchar(50),
lastName varchar(50),
userName varchar(50),
password varchar(50),
activity int,
isTeamLeader bit -- if true - pravo dodijeljivanja aktivnosti clanovima, promjene rokova veifikacije 
-- dokaznica
);

create table activities(
id int not null primary key identity(1,1),
name varchar(50) not null,
description varchar(500),  
dateStart datetime not null, 
dateFinish datetime,
isFinished bit -- team leader ima ovlastenje zatvoriti pojedinu aktivnost 
);

create table proofOfDelivery(
id int not null primary key identity(1,1), 
documentName varchar(50) not null, -- dokument dokaznice npr. izvjesce o provedenoj 
--aktivnosti 4.1. izrada cost benefit analize
location varchar(100)
);

create table connector(
folder int not null,
EUproject int not null
);

create table folders(
id int not null primary key identity(1,1), 
location varchar(50) not null,
contractActivityName varchar(50) not null, -- ovo je ujedno i folder name. Ako je u ugovoru 
-- naziv aktivnosti 1.2. izrada komunikacijske strategije ili 3.1. zakup medijskog prostora 
-- nacionalnih radio postaja zbog kvalitete organizacije korisnik ne treba imati mogucnost
-- slobodnog odabira naziva 
proofOfDelivery int
);

create table activitiesConnector(
EUproject int not null,
activity int not null
);

alter table connector add foreign key (folder) references folders(id); 
alter table connector add foreign key (EUproject) references EUprojects(id); 
alter table teams add foreign key (team) references EUprojects(id);
alter table teams add foreign key (member) references members(id);
alter table activitiesConnector add foreign key (EUproject) references EUprojects(id);
alter table activitiesConnector add foreign key (activity) references activities(id); 
alter table folders add foreign key (id) references proofOfDelivery(id); 