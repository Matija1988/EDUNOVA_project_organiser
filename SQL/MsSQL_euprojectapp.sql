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
name varchar(100) not null,
description varchar(500),  
dateStart datetime not null, -- planirani pocetak aktivnosti
dateFinish datetime not null, -- planirani kraj aktivnosti
folderID int,
isFinished bit, -- team leader ima ovlastenje zatvoriti pojedinu aktivnost
dateAccepted datetime, -- kraj aktivnosti
projectID int not null -- jedna aktivnost pripada jednom projektu  
);

create table proofOfDelivery(
id int not null primary key identity(1,1), 
documentName varchar(100) not null, -- dokument dokaznice npr. izvjesce o provedenoj 
--aktivnosti 4.1. izrada cost benefit analize
location varchar(100) not null,
dateCreated datetime
);


create table folders( -- uzima dokaznice sa više lokacija i objedinjuje ih 
id int not null primary key identity(1,1), 
location varchar(100) not null,
contractActivityName varchar(100) not null, -- ovo je ujedno i folder name. 
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
'2024-11-21 12:00:00', 0),('UZ-54-2-I','Uspostava regionalnog centra kompetentnosti Srednja strukovna
škola Bubimir','2021-1-1 09:00:00','2023-12-29',0), ('A4-K-7-762','Zelene staze Dunava i Drave',
'2019-4-12 8:00:00','2022-5-1 17:00:00',1),
('INTER-HU-CRO-213-D-91','INTEREG-Hungary-Croatia cluster sustainability du dah','2023-1-20 10:00:00',
'2023-10-20',1);

insert into proofOfDelivery (documentName, location, dateCreated)
values ('Analiza troškova i koristi','C:\user\documents\','2023-12-15 12:00:00'),
('RCKSSB marketing plan Otvoreni radio','C:\user\documents','2021-10-10 11:00:00'), 
('Komunikacijska strategija','F:\A4-K-7-762\1.3 Izrada komunikacijske strategije\','2019-10-22'),
('Zapisnik sa koordinacijskog sastanka', 'D:\razno\', '2021-1-15 11:00:00'),
('export.zip', 'G:\foto\', '2020-4-17 21:00:00'),
('Mađari predavanje','D:\','2023-5-5 10:00:00'),
('Videozapis o projektnoj aktivnosti stručnog usavršavanja mentora kod poslodavaca.mp4',
'C:\user\downloads\','2023-9-12 12:00:00'),
('Zapisnik','D:\razno\','2021-2-20 12:00:00');

insert into folders (location, contractActivityName, proofOfDelivery)
values ('d:\JP21-21KD\1.1. Izrada analize troškova i korsti','Analiza troškova i koristi',1),
('d:\UZ-54-2-I\1.3 Izrada komunikacijske strategije\', 'Izrada komunikacijske strategije',2),
('d:\A4-K-7-762\2.1. Zakup medijskog prostora na nacionalnim radio postajama','Potvrda o emitiranju
Otvoreni radio',3), ('d:\UZ-54-2-I\4.1. Koordinacijski sastanci\4.1.1.\','Dokaznica o održanom mjesečnom 
koordinacijskom sastanku 2021_1_15',4), 
('d:\A4-K-7-762\3.2. Redovno fotografiranje aktivnosti projekta\','Postavljanje edukativnih tabli.zip',5),
('d:\INTER-REG HU-CRO','2.1. Educational workshop on agricultural sustainability',6),
('d:\UZ-54-2-I\7. Izrada videozapisa o aktivnostima projekta\7.12.\',
'7.12.Videozapis o projektnoj aktivnosti stručnog usavršavanja mentora kod poslodavaca.zip',7),
('d:\UZ-54-2-I\4.1. Koordinacijski sastanci\4.1.2.\','Dokaznica o održanom mjesečnom 
koordinacijskom sastanku 2021_2_20',4); 
insert activities (name, description, dateStart, dateFinish, folderID, isFinished, dateAccepted, projectID)
values ('1.1.Izrada analize troškova i koristi','Energetska obnova zgrade ... mora uključivati
izolaciju vanjskog zida, dizalicu topline, ugradnju PVC stolarije, fotonaponske ćelije 12 kw/h ...
','2023-6-1 09:00:00','2023-8-1 09:00:00',1, 1,'2023-7-29 12:00:00', 1),
('2.1. Zakup medijskog prostora na nacionalnim radio postajama','Izrada radio jingla 30 sekundi, zakup
nacionalne radio postaje za 50 emitiranja','2021-02-15 11:00:00','2021-03-28 17:00:00',3,0,
'2021-04-01 09:00:00',2),
('1.3 Izrada komunikacijske strategije','Komunikacijska strategija promocije eko-edukativne staze na 
potezu PP Drava-Mura mora uključivati zakup 2x lokalnih, 1x regionalnih i 1x nacionalnih radio postaja, 
2x nacionalne dnevne novine ....','2019-5-1 09:00','2019-6-1 11:00:00',2,1,'2019-6-3 12:00:00',3),
('4.1. Koordinacijski sastanci','Izvršitelj je dužan napraviti zapisnik, držati
potpisne liste te osigurati fotografski dokaz mjesečnih koordinacijskih sastanaka','2021-1-15 09:00:00',
'2021-1-16 11:00:00',4,1,'2021-1-16 13:00:00',2),
('3.2. Redovno fotografiranje aktivnosti projekta','Na poziv Naručitelja Izvršitelj je dužan fotografirati
ključne faze provedbe projekta, 10x dostvljanje min rezolucije 4000x3000 300dpi','2020-4-17 8:00:00',
'2020-4-17 21:00:00',5, 1,'2020-4-18 12:00:00', 3),
('2.1. Educational workshop on agricultural sustainability','Organizacija edukativne radionice 
na temu održivosti u poljoprivredi - obavezan predavač iz Mađarske (kontaktirati partnere) i iz
Hrvatske - osigurati audio tehniku i projektor - minimalno 30 sudionika - catering za 40 osoba - 
promocija na lokalnom web protalu (banner na 10 000 impresija i pr članak)','2023-5-4 9:00:00',
'2023-5-4 11:00:00',6,1,'2023-5-7 13:00:00',4),
('7.2.Videozapis o projektnoj aktivnosti stručnog usavršavanja mentora kod poslodavaca',
'Videozapis o stručnom usavršavanju mentora kod poslodavaca - dvodnevna radionica 
isporuka u 1920x1080, audio EBU R 128 standard, trajanje 5 minuta, PAL',
'2023-9-9 09:00:00','2023-9-10 18:00:00',7,1,'2023-9-13 15:00:00',2),
('4.1. Koordinacijski sastanci','Izvršitelj je dužan napraviti zapisnik, držati
potpisne liste te osigurati fotografski dokaz mjesečnih koordinacijskih sastanaka','2021-2-20 09:00:00',
'2021-2-20 12:10:00',8,1,'2021-2-21 09:00:00',2);

insert into members (name, lastName, userName, password, isTeamLeader)
values ('Chuck','Norris','N0rr1s','Sifra12345678889',1),('Marko','Marković','MM007','JamesBlond069',0),
('Petar','Bočkaj','Guc2A','OsvetaKanižlićeve',0);

insert into activitiesConnector(activityID, memberID) 
values (1,1),(2,1),(3,1),(1,2),(2,3),(4,3),(5,1),(6,2), (7,3), (7,1), (8,2); 


