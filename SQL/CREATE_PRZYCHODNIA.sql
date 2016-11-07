/*CREATE DATABASE JanuszMED
g

use JanuszMED
go
*/
CREATE TABLE Choroby(
	IdChoroby varchar(20) PRIMARY KEY,
	Nazwa varchar(50) NOT NULL,
)
go

CREATE TABLE Leki(
	IdLeku integer PRIMARY KEY,
	Nazwa varchar(50) NOT NULL,
	Producent varchar(50) NOT NULL
)
go

CREATE TABLE Lekarze(
	KodLekarza varchar(5) PRIMARY KEY,
	Imie varchar(15) NOT NULL,
	Nazwisko varchar(30) NOT NULL,
	Specjalizacja varchar(50) NOT NULL,
	NrGabinetu integer NOT NULL,			/* czy znakowy - 3 cyfry? */
	NrKontaktowy varchar(9) NOT NULL		/* czy znakowy - 9 cyfr? */
)
go

CREATE TABLE Pacjenci(
	PESEL varchar(11) PRIMARY KEY,
	Imie varchar(15) NOT NULL,
	Nazwisko varchar(30) NOT NULL,
	Ulica varchar(50) NOT NULL,
	NrDomu varchar(5) NOT NULL,
	NrTelefonu varchar(9) NOT NULL,			/* znakowy - 9 cyfr? */
	DataUrodzenia date NOT NULL,
	Wiek varchar(3) NOT NULL,				/* znakowy - 3 cyfry? */
	KodPocztowy varchar(6) NOT NULL,
	Miasto varchar(20) NOT NULL,
)
go

CREATE TABLE Wizyta(
	IdWizyty integer PRIMARY KEY,
	DataRejestracji date NOT NULL,
	DataWizyty date NOT NULL,
	GodzinaWizyty time NOT NULL,
	Oplata decimal(6, 2) NOT NULL,
	FK_PACJENT varchar(11) FOREIGN KEY REFERENCES Pacjenci,
	FK_LEKARZ varchar(5) FOREIGN KEY REFERENCES Lekarze,
	FK_CHOROBA varchar(20) FOREIGN KEY REFERENCES Choroby
)
go

CREATE TABLE Kuracja(
	IdLeku integer FOREIGN KEY REFERENCES Leki,
	IdWizyty integer FOREIGN KEY REFERENCES Wizyta,
	PRIMARY KEY("IdLeku", "IdWizyty")
)
go