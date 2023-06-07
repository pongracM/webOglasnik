/*
SQLyog Community v8.61 
MySQL - 5.5.5-10.4.28-MariaDB : Database - web_oglasnik
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`web_oglasnik` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci */;

USE `web_oglasnik`;

/*Table structure for table `kategorije` */

DROP TABLE IF EXISTS `kategorije`;

CREATE TABLE `kategorije` (
  `sifra` varchar(11) NOT NULL,
  `naziv` varchar(25) NOT NULL,
  PRIMARY KEY (`sifra`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

/*Data for the table `kategorije` */

insert  into `kategorije`(`sifra`,`naziv`) values ('AM','Auto-Moto'),('EL','Elektronika'),('NEK','Nekretnine'),('OST','Ostalo');

/*Table structure for table `korisnici` */

DROP TABLE IF EXISTS `korisnici`;

CREATE TABLE `korisnici` (
  `korisnicko_ime` varchar(30) NOT NULL,
  `email` varchar(50) NOT NULL,
  `ime` varchar(255) NOT NULL,
  `prezime` varchar(255) NOT NULL,
  `lozinka` varchar(255) NOT NULL,
  `ovlast` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`korisnicko_ime`),
  KEY `FK_korisnici_ovlast` (`ovlast`),
  CONSTRAINT `FK_korisnici_ovlast` FOREIGN KEY (`ovlast`) REFERENCES `ovlasti` (`sifra`) ON DELETE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `korisnici` */

insert  into `korisnici`(`korisnicko_ime`,`email`,`ime`,`prezime`,`lozinka`,`ovlast`) values ('admin','admin@net.hr','Jure','Marić','jUPY60RIRBTWGhhlm0Q/v+UjmVENpGidU1K9ljHGxRs=','AD'),('pivanic','pivanic@net.hr','Petar','Ivanić','9OGS0TpjNkgD0+dwSB1lpnsrlAZhsobZwZ5cQEtMOPo=','KO'),('pperic','pperic@net.hr','Pero','Perić','9OGS0TpjNkgD0+dwSB1lpnsrlAZhsobZwZ5cQEtMOPo=','KO');

/*Table structure for table `oglasi` */

DROP TABLE IF EXISTS `oglasi`;

CREATE TABLE `oglasi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `naziv` varchar(75) NOT NULL,
  `opis` varchar(255) NOT NULL,
  `datum_objave` date DEFAULT curdate(),
  `traje_do` date DEFAULT NULL,
  `cijena` decimal(10,2) NOT NULL,
  `kategorija_sifra` varchar(11) DEFAULT NULL,
  `slika` varchar(255) DEFAULT NULL,
  `korisnik` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_OglasKategorija` (`kategorija_sifra`),
  CONSTRAINT `FK_OglasKategorija` FOREIGN KEY (`kategorija_sifra`) REFERENCES `kategorije` (`sifra`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

/*Data for the table `oglasi` */

insert  into `oglasi`(`id`,`naziv`,`opis`,`datum_objave`,`traje_do`,`cijena`,`kategorija_sifra`,`slika`,`korisnik`) values (16,'Kuca','Ima krova i prozore','0001-01-01','2023-06-30','30000.00','NEK','~/Images/caku235716362.png','pperic'),(17,'Racunalo','PC opis','0001-01-01','2023-06-16','500.00','EL','~/Images/pc234857726.jpg','pivanic'),(18,'Auto','Lada Niva','2023-06-06','2023-06-23','15000.00','AM','~/Images/car235305402.jpg','admin');

/*Table structure for table `ovlasti` */

DROP TABLE IF EXISTS `ovlasti`;

CREATE TABLE `ovlasti` (
  `sifra` varchar(5) NOT NULL,
  `naziv` varchar(255) NOT NULL,
  PRIMARY KEY (`sifra`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

/*Data for the table `ovlasti` */

insert  into `ovlasti`(`sifra`,`naziv`) values ('AD','Administrator'),('KO','Korisnik');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
