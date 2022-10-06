 
 CREATE TABLE `category` (
  `Id` int NOT NULL AUTO_INCREMENT COMMENT 'PK',
  `Name` varchar(100) COLLATE utf8mb4_general_ci NOT NULL COMMENT 'Category Name',
  `DisplayOrder` int DEFAULT NULL COMMENT '分類排序',
  `CreateTime` datetime NOT NULL COMMENT 'CreateTime',
  `UpdateTime` datetime DEFAULT NULL COMMENT 'UpdateTime',
  `CreateUser` int NOT NULL COMMENT 'User Id',
  `UpdateUser` int DEFAULT NULL COMMENT 'User Id',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci COMMENT='分類';