IF DB_ID('Employees') IS NULL
CREATE DATABASE Employees
GO
USE Employees;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblEmployee')
drop table tblEmployee;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblSector')
drop table tblSector;

if exists (SELECT name FROM sys.sysobjects WHERE name = 'tblGender')
drop table tblGender;


Create table tblGender (
GenderID int identity (1,1) primary key,
Gender varchar(10)
)

Create table tblSector (
SectorID int identity (1,1) primary key,
SectorName varchar(10)
)

create table tblEmployee(
EmployeeID int identity(1,1) primary key,
FullName varchar(30) not null,
DateOfBirth date not null,
IdCardNumber char(9) check (LEN(IdCardNumber) = 9) not null unique,
JMBG varchar(30) check(len(JMBG) = 13)  not null unique,
GenderID int foreign key (GenderID) references tblGender(GenderID) not null,
PhoneNumber int not null,
SectorID int foreign key (SectorID) references tblSector(SectorID) not null,
LocationOfEmployee varchar(30) not null,
Manager int not null,
constraint checkJMBG check(JMBG not like '%[^0-9]%'))

insert into tblGender (Gender)
values('Male');

insert into tblGender (Gender)
values('Female');

insert into tblGender (Gender)
values('Other');

