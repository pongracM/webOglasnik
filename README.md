# webOglasnik naredbe za bazu

naredbe za napraviti bazu

******************************************************************************************************************

/*     Kreiranje baze i korisnika       */

CREATE DATABASE IF NOT EXISTS `web_oglasnik` DEFAULT CHARACTER SET utf8;

CREATE USER 'weboglasnik'@'localhost' IDENTIFIED BY 'weboglasnik'; 
GRANT ALL PRIVILEGES ON web_oglasnik.* TO 'weboglasnik'@'localhost';

/*     Kreiranje tablice oglasi       */

USE web_oglasnik;

CREATE TABLE oglasi (
  id INT(11) NOT NULL AUTO_INCREMENT,
  naziv VARCHAR(75) NOT NULL,
  opis VARCHAR(255) NOT NULL,
  datum_objave DATE DEFAULT CURRENT_DATE(),
  traje_do DATE DEFAULT NULL,
  cijena DECIMAL(10 ,2) NOT NULL,
  PRIMARY KEY (id)
);

/*    Popunjavanje tablice oglasi vrijednosti su bezveze samo za probu*/

INSERT INTO `oglasi` (`id`, `naziv`, `opis`, `datum_objave`, `traje_do`, `cijena`) VALUES
(1, 'probaNaziv1', 'probaOpis1', CURRENT_DATE(), '2023-8-15', '132443,03'),
(2, 'probaNaziv2', 'probaOpis2', CURRENT_DATE(), '2023-9-16', '27343,32'),
(3, 'probaNaziv3', 'probaOpis3', CURRENT_DATE(), '2023-11-23', '675,97');

/*     Kreiranje tablice kategorije       */

USE web_oglasnik;

CREATE TABLE kategorije (
  sifra VARCHAR(11),
  naziv VARCHAR(25) NOT NULL,
  PRIMARY KEY (sifra)
);

/*    Popunjavanje tablice kategorije        */

INSERT INTO `kategorije` (`sifra`, `naziv`) VALUES
('am', 'auto moto'),
('nek', 'nekretnine'),
('el', 'elektronika');

/*        Spajanje tablica    */

ALTER TABLE oglasi 
  ADD kategorija_sifra VARCHAR(11);

ALTER TABLE oglasi
  ADD CONSTRAINT FK_OglasKategorija
  FOREIGN KEY (kategorija_sifra) REFERENCES kategorije(sifra);



/*                  Kreiranje korisnika i ovlasti                    */

USE web_oglasnik;

CREATE TABLE ovlasti (
  sifra VARCHAR(5) NOT NULL,
  naziv VARCHAR(255) NOT NULL,
  PRIMARY KEY (sifra)
) ENGINE=INNODB DEFAULT CHARSET=utf8mb4;

INSERT INTO ovlasti(sifra,naziv) VALUES('AD','Administrator'),('KO','Korisnik');

CREATE TABLE korisnici (
  korisnicko_ime VARCHAR(30) NOT NULL,
  email VARCHAR(50) NOT NULL,
  ime VARCHAR(255) NOT NULL,
  prezime VARCHAR(255) NOT NULL,
  lozinka VARCHAR(255) NOT NULL, 
  ovlast VARCHAR(5) DEFAULT NULL,
  PRIMARY KEY (korisnicko_ime),
  KEY FK_korisnici_ovlast (ovlast),
  CONSTRAINT FK_korisnici_ovlast FOREIGN KEY (ovlast) REFERENCES ovlasti (sifra) ON DELETE NO ACTION
) ENGINE=INNODB DEFAULT CHARSET=utf8mb4;


INSERT INTO korisnici(korisnicko_ime,email,prezime,ime,lozinka,ovlast) VALUES
('admin','admin@net.hr','Marić','Jure','jUPY60RIRBTWGhhlm0Q/v+UjmVENpGidU1K9ljHGxRs=','AD'),
('pivanic','pivanic@net.hr','Ivanić','Petar','9OGS0TpjNkgD0+dwSB1lpnsrlAZhsobZwZ5cQEtMOPo=','KO');

/*                                 Slike                                                      */

USE web_oglasnik;
ALTER TABLE oglasi ADD slika VARCHAR(255);


*************************************************************************************************************
