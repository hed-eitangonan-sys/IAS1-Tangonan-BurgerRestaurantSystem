CREATE DATABASE burger_db;
USE burger_db;

CREATE TABLE menu_tbl
(
	id INT PRIMARY KEY AUTO_INCREMENT,
    item_name VARCHAR(100),
    price DECIMAL
);

CREATE TABLE audit_tbl
(
	userid INT,
	username VARCHAR(100),
    activity VARCHAR(255),
    log_date DATETIME
);