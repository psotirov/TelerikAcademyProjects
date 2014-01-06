-- MySQL dump 10.13  Distrib 5.5.24, for Win64 (x86)
--
-- Host: localhost    Database: books
-- ------------------------------------------------------
-- Server version	5.5.24-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `books` (
  `BooksId` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Title` varchar(45) NOT NULL,
  `Author` varchar(45) NOT NULL,
  `PublishDate` datetime DEFAULT NULL,
  `ISBN` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`BooksId`),
  UNIQUE KEY `BooksId_UNIQUE` (`BooksId`),
  KEY `FK_Author_idx` (`Author`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1,'Head First Java, 2nd Edition','Kathy Sierra','2005-01-01 00:00:00','978-0-596-00920-5'),(2,'Professional ASP.NET 4 in C# and VB','Scott Hanselman','2010-01-01 00:00:00','978-1-4571-0402-2'),(3,'Ubuntu Unleashed 2010 Edition, 5th Edition','Andrew Hudson','2009-01-01 00:00:00','978-0-672-33109-1'),(4,'Android Application Development For Dummies, ','Michael Burton','2012-01-01 00:00:00','978-1-118-38710-8'),(6,'Advanced Joomla!','Dan Rahmel','2013-01-01 00:00:00','978-1-4302-1628-5'),(7,'Advanced Joomla!','Dan Rahmel','2013-01-01 00:00:00','978-1-4302-1628-5'),(8,'Advanced Joomla!','Dan Rahmel','2013-01-01 00:00:00','978-1-4302-1628-5'),(9,'Advanced Joomla!','Dan Rahmel','2013-01-01 00:00:00','978-1-4302-1628-5');
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-07-16 19:53:34
