create database [Users]
use [Users]
create table users
(
id int primary key,
fname varchar(20) not null,
lname varchar(20) not null,
password varchar(20)
)
insert into users(id,fname,lname,password)
values (1, 'Delo','Brunchev','1596322as')
insert into users(id,fname,lname,password)
values (2, 'Nikola','Todorov','sadas12')
insert into users(id,fname,lname,password)
values (3, 'Simona','Todorova','wefwe32234')
insert into users(id,fname,lname,password)
values (4, 'Silviq','Nenkova','asfedfwef2')