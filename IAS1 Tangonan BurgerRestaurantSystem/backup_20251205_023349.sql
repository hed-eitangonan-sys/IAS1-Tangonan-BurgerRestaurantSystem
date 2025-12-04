-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: burger_db
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `burger_db`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `burger_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `burger_db`;

--
-- Table structure for table `audit_tbl`
--

DROP TABLE IF EXISTS `audit_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `audit_tbl` (
  `userid` int DEFAULT NULL,
  `username` varchar(100) DEFAULT NULL,
  `activity` varchar(255) DEFAULT NULL,
  `log_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `audit_tbl`
--

LOCK TABLES `audit_tbl` WRITE;
/*!40000 ALTER TABLE `audit_tbl` DISABLE KEYS */;
INSERT INTO `audit_tbl` VALUES (1,'admin','Added item: item_name=\'Cheeseburger na walang cheese\', price=\'Cheeseburger na walang cheese\'','2025-12-04 22:01:43'),(1,'admin','Added item: item_name=\'Double Cheese Burger\', price=\'Double Cheese Burger\'','2025-12-04 23:26:46'),(1,'admin','Added item: item_name=\'Cheeseburger\', price=\'Cheeseburger\'','2025-12-04 23:26:58'),(1,'admin','Item deleted: item_name=\'Cheeseburger\', price=\'Cheeseburger\'','2025-12-04 23:27:01'),(1,'admin','Item deleted: item_name=\'Double Cheese Burger\', price=\'Double Cheese Burger\'','2025-12-04 23:27:21'),(1,'admin','User logged out due to inactivity','2025-12-05 01:05:13'),(1,'admin','User logged out due to inactivity','2025-12-05 01:05:45'),(1,'admin','Added item: item_name=\'Cheeseburger na walang cheese\', price=\'53\'','2025-12-05 01:08:05'),(1,'admin','Item deleted: item_name=\'Cheeseburger na walang cheese\', price=\'53\'','2025-12-05 01:08:16'),(1,'admin','User logged out due to inactivity from Dashboard','2025-12-05 01:39:13'),(1,'admin','User logged out due to inactivity','2025-12-05 02:06:35'),(1,'admin','User logged out due to inactivity from Dashboard','2025-12-05 02:09:55'),(1,'admin','New user registered: IanPogi@18','2025-12-05 02:24:35');
/*!40000 ALTER TABLE `audit_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_tbl`
--

DROP TABLE IF EXISTS `menu_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_tbl` (
  `id` int NOT NULL AUTO_INCREMENT,
  `item_name` varchar(100) DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_tbl`
--

LOCK TABLES `menu_tbl` WRITE;
/*!40000 ALTER TABLE `menu_tbl` DISABLE KEYS */;
INSERT INTO `menu_tbl` VALUES (2,'Cheeseburger',33),(6,'Cheeseburger na walang cheese',53);
/*!40000 ALTER TABLE `menu_tbl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_tbl`
--

DROP TABLE IF EXISTS `user_tbl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_tbl` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(64) NOT NULL,
  `status` enum('Active','Inactive','Pending') NOT NULL DEFAULT 'Pending',
  `role` enum('Admin','User') NOT NULL DEFAULT 'Admin',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_tbl`
--

LOCK TABLES `user_tbl` WRITE;
/*!40000 ALTER TABLE `user_tbl` DISABLE KEYS */;
INSERT INTO `user_tbl` VALUES (1,'ian','ian','Active','Admin'),(4,'dasdsd','Adsas.463563454','Inactive','User'),(5,'IanPogi@18','IanPogi@18','Active','User');
/*!40000 ALTER TABLE `user_tbl` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-12-05  2:33:54
