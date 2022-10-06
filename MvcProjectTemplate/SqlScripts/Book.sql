
CREATE TABLE `book` (
  `Id` int NOT NULL AUTO_INCREMENT COMMENT 'PK',
  `CategoryId` int NOT NULL COMMENT 'Category Id',
  `ISBN` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'ISBN',
  `Author` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'Author',
  `Title` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT 'Title',
  `Description` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL COMMENT 'Description',
  `CreateTime` datetime NOT NULL COMMENT 'CreateTime',
  `UpdateTime` datetime DEFAULT NULL COMMENT 'UpdateTime',
  `CreateUser` int NOT NULL COMMENT 'User Id',
  `UpdateUser` int DEFAULT NULL COMMENT 'User Id',
  PRIMARY KEY (`Id`),
  KEY `CategoryId` (`CategoryId`),
  CONSTRAINT `book_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='書';