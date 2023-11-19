use master;
go
drop database projectsAPP;
go
create database projectsApp;
go
alter database projectsApp collate Croatian_CI_AS;
go
use projectsApp;

create table projects (
id int not null primary key identity (1,1), 
uniqueIDnumber varchar(50) not null, -- identifikacijska sifra projekta npr. K.K. 1012
name varchar(100) not null, -- puni naziv projekta
dateStart datetime,  
dateEnd datetime, 
isFinished bit,

);


create table members(
id int not null primary key identity(1,1),
name varchar(50),
lastName varchar(50),
userName varchar(50),
password varchar(50),
isTeamLeader bit -- if true - pravo dodjeljivanja aktivnosti clanovima, promjene rokova veifikacije 
-- dokaznica
);

create table activities(
id int not null primary key identity(1,1),
name varchar(50) not null,
description varchar(500),  
dateStart datetime not null, -- planirani pocetak aktivnosti
dateFinish datetime not null, -- planirani kraj aktivnosti
folderID int,
isFinished bit, -- team leader ima ovlastenje zatvoriti pojedinu aktivnost
dateFinished datetime, -- kraj aktivnosti
projectID int not null -- jedna aktivnost pripada jednom projektu  
);

create table proofOfDelivery(
id int not null primary key identity(1,1), 
documentName varchar(50) not null, -- dokument dokaznice npr. izvjesce o provedenoj 
--aktivnosti 4.1. izrada cost benefit analize
location varchar(100) not null,
dateCreated datetime
);


create table folders( -- uzima dokaznice sa više lokacija i objedinjuje ih 
id int not null primary key identity(1,1), 
location varchar(100) not null,
contractActivityName varchar(50) not null, -- ovo je ujedno i folder name. 
proofOfDelivery int 
);

create table activitiesConnector(
activityID int not null,
memberID int not null
);
alter table activities add foreign key (folderID) references folders(id);
alter table activities add foreign key (projectID) references projects(id);
alter table activitiesConnector add foreign key (activityID) references activities(id); 
alter table activitiesConnector add foreign key (memberID) references members(id);
alter table folders add foreign key (id) references proofOfDelivery(id); 

insert into projects (uniqueIDnumber, name, dateStart, dateEnd, isFinished) 
values ('JP21-21KD', 'Poboljšanje energetske učinkovitosti zgrade Zamišljena Adresa 2', '2023-5-21 09:00:00', 
'2024-11-21 12:00:00', 0);

insert into proofOfDelivery (documentName, location, dateCreated)
values ('Analiza troškova i koristi','C:\user\documents\','2023-12-15 12:00:00');

insert into folders (location, contractActivityName, proofOfDelivery)
values ('d:\JP21-21KD\1.1. Izrada analize troškova i korsti','Analiza troškova i koristi',1);

insert activities (name, description, dateStart, dateFinish, folderID, isFinished, dateFinished, projectID)
values ('1.1.Izrada analize troškova i koristi','Energetska obnova zgrade ... mora uključivati
izolaciju vanjskog zida, dizalicu topline, ugradnju PVC stolarije, fotonaponske ćelije 12 kw/h ...
','2023-6-1 09:00:00','2023-8-1 09:00:00',1, 1,'2023-7-29 12:00:00', 1);

insert into members (name, lastName, userName, password, isTeamLeader)
values ('Chuck','Norris','N0rr1s','Sifra12345678889',1);

insert into activitiesConnector(activityID, memberID) 
values (1,1); 


