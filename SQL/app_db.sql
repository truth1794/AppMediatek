-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 31, 2023 at 08:22 PM
-- Server version: 10.10.2-MariaDB
-- PHP Version: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `app_db`
--
CREATE DATABASE IF NOT EXISTS `app_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `app_db`;

-- --------------------------------------------------------

--
-- Table structure for table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `IDPERSONNEL` int(11) NOT NULL,
  `DATEDEBUT` datetime NOT NULL,
  `IDMOTIF` int(11) NOT NULL,
  `DATEFIN` datetime DEFAULT NULL,
  PRIMARY KEY (`IDPERSONNEL`,`DATEDEBUT`),
  KEY `FK_ABSENCE_MOTIF` (`IDMOTIF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `absence`
--

INSERT INTO `absence` (`IDPERSONNEL`, `DATEDEBUT`, `IDMOTIF`, `DATEFIN`) VALUES
(1, '2021-02-22 05:36:30', 3, '2022-08-08 09:32:46'),
(1, '2021-07-03 05:00:20', 1, '2022-11-28 23:48:09'),
(1, '2021-09-10 09:33:07', 2, '2022-12-29 11:02:38'),
(1, '2023-04-01 00:00:00', 4, '2023-04-07 00:00:00'),
(2, '2021-03-30 10:14:52', 2, '2022-06-15 15:30:36'),
(2, '2021-08-01 08:25:16', 4, '2022-11-13 20:21:48'),
(2, '2021-08-31 16:40:07', 2, '2022-10-04 16:18:34'),
(2, '2021-09-23 23:34:20', 2, '2022-11-12 17:09:08'),
(2, '2022-04-11 12:40:50', 2, '2022-07-22 14:17:22'),
(4, '2021-02-07 05:20:09', 4, '2022-12-17 19:15:39'),
(4, '2021-04-19 15:13:31', 3, '2022-09-10 10:32:59'),
(4, '2022-01-08 12:57:27', 2, '2022-12-02 14:56:59'),
(4, '2022-05-31 14:17:25', 1, '2022-12-18 07:08:30'),
(5, '2021-03-29 13:08:00', 3, '2022-08-26 14:22:57'),
(5, '2021-06-04 00:00:00', 1, '2022-09-01 00:00:00'),
(5, '2021-12-26 00:00:00', 2, '2022-06-23 00:00:00'),
(5, '2022-03-14 06:33:09', 3, '2022-12-06 23:21:32'),
(5, '2023-04-01 00:00:00', 1, '2023-04-08 00:00:00'),
(6, '2021-01-11 05:53:03', 3, '2022-11-20 12:23:42'),
(6, '2021-02-25 03:01:42', 2, '2022-11-28 10:44:13'),
(6, '2021-12-15 03:38:59', 1, '2022-06-12 15:16:57'),
(6, '2022-03-04 03:29:32', 3, '2022-06-14 14:29:51'),
(6, '2022-05-13 20:32:02', 2, '2022-06-08 22:00:53'),
(7, '2021-01-25 16:01:03', 2, '2022-12-27 06:27:10'),
(7, '2021-02-07 06:48:36', 2, '2022-08-16 22:47:01'),
(7, '2021-04-16 00:00:00', 1, '2022-08-27 00:00:00'),
(7, '2022-05-02 01:08:09', 3, '2022-11-01 15:33:19'),
(8, '2021-01-04 05:29:44', 2, '2022-07-26 19:11:37'),
(8, '2021-02-25 05:36:30', 2, '2022-08-08 09:32:46'),
(8, '2021-11-10 07:45:11', 1, '2022-06-07 02:17:27'),
(8, '2022-01-05 04:33:06', 2, '2022-08-27 14:21:48'),
(8, '2022-02-04 16:15:13', 3, '2022-10-23 10:08:41'),
(8, '2023-04-23 00:00:00', 3, '2023-04-24 00:00:00'),
(9, '2021-04-25 08:06:55', 3, '2022-08-30 01:06:51'),
(9, '2021-09-10 02:52:12', 3, '2022-08-28 08:23:34'),
(9, '2021-10-08 10:39:18', 1, '2022-06-29 23:39:41'),
(9, '2022-06-19 19:14:34', 2, '2022-09-01 12:55:03');

-- --------------------------------------------------------

--
-- Table structure for table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `IDMOTIF` int(11) NOT NULL AUTO_INCREMENT,
  `LIBELLE` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`IDMOTIF`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `motif`
--

INSERT INTO `motif` (`IDMOTIF`, `LIBELLE`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'conge parental');

-- --------------------------------------------------------

--
-- Table structure for table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `IDPERSONNEL` int(11) NOT NULL AUTO_INCREMENT,
  `IDSERVICE` int(11) NOT NULL,
  `NOM` varchar(50) DEFAULT NULL,
  `PRENOM` varchar(50) DEFAULT NULL,
  `TEL` varchar(15) DEFAULT NULL,
  `MAIL` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`IDPERSONNEL`),
  KEY `FK_PERSONNEL_SERVICE` (`IDSERVICE`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `personnel`
--

INSERT INTO `personnel` (`IDPERSONNEL`, `IDSERVICE`, `NOM`, `PRENOM`, `TEL`, `MAIL`) VALUES
(1, 2, 'Dion', 'Celine', '04 37 42 98 69', 'non.magna@outlook.edu'),
(2, 1, 'Jonker', 'Serina', '04 71 31 69 08', 'nec.mollis@outlook.com'),
(4, 4, 'Fontaine', 'Mariam', '08 11 26 85 64', 'mauris@yahoo.net'),
(5, 2, 'Mills', 'Jillian', '01 31 65 35 23', 'diam@hotmail.edu'),
(6, 3, 'Bouwmeester', 'Sarah', '01 89 50 12 87', 'id.ante@icloud.tg'),
(7, 4, 'Paquette', 'Summer', '02 09 01 40 76', 'eu.augue.porttitor@outlook.org'),
(8, 1, 'Offermans', 'Cedric', '09 51 11 28 06', 'libero.et.tristique@outlook.couk'),
(9, 1, 'Proulx', 'Ora', '05 35 17 77 78', 'faucibus@icloud.org'),
(23, 4, 'John', 'Durand', '258965574', 'jd76@gmail.com'),
(24, 2, 'Frederic', 'Poulard', '08 45 78 65 85', 'fp@gmail.fr');

-- --------------------------------------------------------

--
-- Table structure for table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) NOT NULL,
  `pwd` varchar(64) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin0', '53fe36057aa96d1aec2f4055a8f985f4f2c2f920b5c82ba270268bce831f174c');

-- --------------------------------------------------------

--
-- Table structure for table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `IDSERVICE` int(11) NOT NULL AUTO_INCREMENT,
  `NOM` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IDSERVICE`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `service`
--

INSERT INTO `service` (`IDSERVICE`, `NOM`) VALUES
(1, 'administratif'),
(2, 'mediation'),
(3, 'culturelle'),
(4, 'pret');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `absence`
--
ALTER TABLE `absence`
  ADD CONSTRAINT `FK_ABSENCE_MOTIF` FOREIGN KEY (`IDMOTIF`) REFERENCES `motif` (`IDMOTIF`),
  ADD CONSTRAINT `FK_ABSENCE_PERSONNEL` FOREIGN KEY (`IDPERSONNEL`) REFERENCES `personnel` (`IDPERSONNEL`);

--
-- Constraints for table `personnel`
--
ALTER TABLE `personnel`
  ADD CONSTRAINT `FK_PERSONNEL_SERVICE` FOREIGN KEY (`IDSERVICE`) REFERENCES `service` (`IDSERVICE`);
COMMIT;

DROP USER IF EXISTS 'app_admin'@'localhost';
FLUSH PRIVILEGES;
CREATE USER 'app_admin'@'localhost' IDENTIFIED BY '8756F069B38300B2E5F5B76467D8310090AC13EE';
GRANT ALL PRIVILEGES ON app_db.* TO 'app_admin'@'localhost' WITH GRANT OPTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
