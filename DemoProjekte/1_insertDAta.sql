use dbTestITIN22
go

declare @idRolle int
declare @idBenutzer int
declare @idKategorie int
declare @idWare int
declare @idRechnung int

delete from tblRechnungsWaren
delete from tblRechnungen
delete from tblWaren
delete from tblKategorien

delete from tblBenutzer
delete from tblRollen


insert into tblRollen(bezeichnung) values ('Benutzer')
select @idRolle = @@IDENTITY

insert into tblRollen(bezeichnung) values ('Administrator')


insert into tblBenutzer(benutzername, passwort, nachname, idRolle) values ('max.muster', HASHBYTES('SHA2_512','123user!'), 'muster', @idRolle)
select @idBenutzer = @@IDENTITY

insert into tblKategorien (bezeichnung) values ('Obst')
select @idKategorie = @@IDENTITY

insert into tblWaren (bezeichnung, preis, idKategorie) values ('banana', 1.99, @idKategorie)
select @idWare= @@IDENTITY

insert into tblRechnungen (idBenutzer, datum) values (@idBenutzer, GETDATE())
select @idRechnung= @@IDENTITY

insert into tblRechnungsWaren(idRechnung, idWare, menge) values (@idRechnung,@idWare, 4)



