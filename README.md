# C# CRUD URSS Manager

Dépot GIT pour le projet de CRUD en C# (URSS Manager) dans le cadre de la LP DIM



### Installation base de données

```

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";

CREATE TABLE `peuple` (
  `PersonneID` int(11) NOT NULL,
  `Nom` varchar(50) NOT NULL,
  `Age` int(11) NOT NULL,
  `Ville` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `peuple` (`PersonneID`, `Nom`, `Age`, `Ville`) VALUES
(1, 'Michel', 45, 'Moscou');

ALTER TABLE `peuple`
  ADD PRIMARY KEY (`PersonneID`);
  
ALTER TABLE `peuple`
  MODIFY `PersonneID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

```

### Configuration

On utilise une base de données MySQL via un xampp.
Il faut donc avoir dans les références du projet "MySql.Data.dll".
