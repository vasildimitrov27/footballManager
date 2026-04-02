-- 1. СЪЗДАВАНЕ НА БАЗАТА ДАННИ
CREATE DATABASE IF NOT EXISTS football_manager CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE football_manager;

-- Спираме проверките за чужди ключове, за да можем да изтриваме и създаваме наново без грешки
SET FOREIGN_KEY_CHECKS = 0;

-- 2. ИЗТРИВАНЕ НА СТАРИ ТАБЛИЦИ (Ако съществуват)
DROP TABLE IF EXISTS match_events;
DROP TABLE IF EXISTS matches;
DROP TABLE IF EXISTS transfers;
DROP TABLE IF EXISTS league_teams;
DROP TABLE IF EXISTS players;
DROP TABLE IF EXISTS clubs;
DROP TABLE IF EXISTS leagues;

-- 3. СЪЗДАВАНЕ НА ТАБЛИЦИ (DDL)

-- Таблица: Лиги (Етап 5)
CREATE TABLE leagues (
    LeagueId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Season VARCHAR(9) NOT NULL, -- Формат: 2025/2026
    UNIQUE(Name, Season)
) ENGINE=InnoDB;

-- Таблица: Клубове (Етап 2)
CREATE TABLE clubs (
    ClubId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL UNIQUE,
    City VARCHAR(100),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- Таблица: Играчи (Етап 3)
CREATE TABLE players (
    PlayerId INT AUTO_INCREMENT PRIMARY KEY,
    ClubId INT NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL,
    Position ENUM('GK', 'DF', 'MF', 'FW') NOT NULL,
    ShirtNumber INT,
    FOREIGN KEY (ClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT
) ENGINE=InnoDB;

-- Таблица: Участници в Лиги (Етап 5 - Many-to-Many)
CREATE TABLE league_teams (
    LeagueId INT NOT NULL,
    ClubId INT NOT NULL,
    PRIMARY KEY (LeagueId, ClubId),
    FOREIGN KEY (LeagueId) REFERENCES leagues(LeagueId) ON DELETE CASCADE,
    FOREIGN KEY (ClubId) REFERENCES clubs(ClubId) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Таблица: Трансфери (Етап 4)
CREATE TABLE transfers (
    TransferId INT AUTO_INCREMENT PRIMARY KEY,
    PlayerId INT NOT NULL,
    FromClubId INT, 
    ToClubId INT NOT NULL,
    TransferDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Fee DECIMAL(15, 2) DEFAULT 0.00,
    Note TEXT,
    FOREIGN KEY (PlayerId) REFERENCES players(PlayerId) ON DELETE CASCADE,
    FOREIGN KEY (FromClubId) REFERENCES clubs(ClubId) ON DELETE SET NULL,
    FOREIGN KEY (ToClubId) REFERENCES clubs(ClubId) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Таблица: Мачове (Етап 1)
CREATE TABLE matches (
    MatchId INT AUTO_INCREMENT PRIMARY KEY,
    LeagueId INT NOT NULL,
    HomeClubId INT NOT NULL,
    AwayClubId INT NOT NULL,
    MatchDate DATETIME NOT NULL,
    HomeScore INT DEFAULT 0,
    AwayScore INT DEFAULT 0,
    FOREIGN KEY (LeagueId) REFERENCES leagues(LeagueId) ON DELETE CASCADE,
    FOREIGN KEY (HomeClubId) REFERENCES clubs(ClubId) ON DELETE CASCADE,
    FOREIGN KEY (AwayClubId) REFERENCES clubs(ClubId) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Таблица: Събития в мача (Етап 1)
CREATE TABLE match_events (
    EventId INT AUTO_INCREMENT PRIMARY KEY,
    MatchId INT NOT NULL,
    PlayerId INT NOT NULL,
    EventType ENUM('Goal', 'Yellow Card', 'Red Card') NOT NULL,
    EventMinute INT,
    FOREIGN KEY (MatchId) REFERENCES matches(MatchId) ON DELETE CASCADE,
    FOREIGN KEY (PlayerId) REFERENCES players(PlayerId) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Пускаме проверките обратно
SET FOREIGN_KEY_CHECKS = 1;

-- 4. ПРИМЕРНИ ДАННИ ЗА ТЕСТВАНЕ (SEED)
INSERT INTO leagues (Name, Season) VALUES ('Първа Лига', '2024/2025'), ('Втора Лига', '2024/2025');
INSERT INTO clubs (Name, City) VALUES ('Левски', 'София'), ('ЦСКА', 'София'), ('Лудогорец', 'Разград');
INSERT INTO players (ClubId, FullName, BirthDate, Position, ShirtNumber) VALUES (1, 'Марин Петков', '2003-10-02', 'FW', 88);

-- Регистриране на Левски в Първа Лига
INSERT INTO league_teams (LeagueId, ClubId) VALUES (1, 1);
