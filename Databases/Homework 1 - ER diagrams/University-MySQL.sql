SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `University` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `University` ;

-- -----------------------------------------------------
-- Table `University`.`Faculties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Faculties` (
  `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(50) NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Departments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Departments` (
  `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(50) NULL ,
  `FacultyId` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) ,
  UNIQUE INDEX `FacultyId_UNIQUE` (`FacultyId` ASC) ,
  CONSTRAINT `fk_FacultyDepartment`
    FOREIGN KEY (`FacultyId` )
    REFERENCES `University`.`Faculties` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Professors`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Professors` (
  `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(45) NULL ,
  `DepartmentId` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) ,
  UNIQUE INDEX `DepartmentId_UNIQUE` (`DepartmentId` ASC) ,
  CONSTRAINT `fk_DepartmentProfessor`
    FOREIGN KEY (`DepartmentId` )
    REFERENCES `University`.`Departments` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Titles`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Titles` (
  `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `TitleName` VARCHAR(45) NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Courses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Courses` (
  `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `CourseName` VARCHAR(45) NULL ,
  `DepartmentId` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) ,
  INDEX `fk_DepartmentCourse_idx` (`DepartmentId` ASC) ,
  CONSTRAINT `fk_DepartmentCourse`
    FOREIGN KEY (`DepartmentId` )
    REFERENCES `University`.`Departments` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Students`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`Students` (
  `Id` INT UNSIGNED NOT NULL AUTO_INCREMENT ,
  `FirstName` VARCHAR(45) NULL ,
  `LastName` VARCHAR(45) NULL ,
  `SSID` INT UNSIGNED NULL ,
  `FacultyId` INT UNSIGNED NULL ,
  PRIMARY KEY (`Id`) ,
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) ,
  UNIQUE INDEX `SSID_UNIQUE` (`SSID` ASC) ,
  UNIQUE INDEX `DepartmentId_UNIQUE` (`FacultyId` ASC) ,
  CONSTRAINT `fk_Faculty_Student`
    FOREIGN KEY (`FacultyId` )
    REFERENCES `University`.`Faculties` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`ProfessorsTitles`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`ProfessorsTitles` (
  `ProfessorId` INT UNSIGNED NOT NULL ,
  `TitleId` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`ProfessorId`, `TitleId`) ,
  INDEX `fk_ProfessorId_idx` (`ProfessorId` ASC) ,
  INDEX `fk_TitleId_idx` (`TitleId` ASC) ,
  CONSTRAINT `fk_ProfessorId`
    FOREIGN KEY (`ProfessorId` )
    REFERENCES `University`.`Professors` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_TitleId`
    FOREIGN KEY (`TitleId` )
    REFERENCES `University`.`Titles` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
PACK_KEYS = 1;


-- -----------------------------------------------------
-- Table `University`.`ProfessorsCourses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`ProfessorsCourses` (
  `ProfessorId` INT UNSIGNED NOT NULL ,
  `CourseId` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`ProfessorId`, `CourseId`) ,
  INDEX `fk_ProfessorId_idx` (`ProfessorId` ASC) ,
  INDEX `fk_CourseProfessor_idx` (`CourseId` ASC) ,
  CONSTRAINT `fk_ProfessorCourse`
    FOREIGN KEY (`ProfessorId` )
    REFERENCES `University`.`Professors` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_CourseProfessor`
    FOREIGN KEY (`CourseId` )
    REFERENCES `University`.`Courses` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`StudentsCourses`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `University`.`StudentsCourses` (
  `StudentId` INT UNSIGNED NOT NULL ,
  `CourseId` INT UNSIGNED NOT NULL ,
  PRIMARY KEY (`StudentId`, `CourseId`) ,
  INDEX `StudentId_idx` (`StudentId` ASC) ,
  INDEX `CourseId_idx` (`CourseId` ASC) ,
  CONSTRAINT `fk_StudentId`
    FOREIGN KEY (`StudentId` )
    REFERENCES `University`.`Students` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_CourseId`
    FOREIGN KEY (`CourseId` )
    REFERENCES `University`.`Courses` (`Id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `University` ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
