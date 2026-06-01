-- 1. СЪЗДАВАНЕ НА БАЗАТА ДАННИ
CREATE DATABASE IF NOT EXISTS football_manager CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE football_manager;

-- Спираме проверките за чужди ключове, за да можем да трием/създаваме свободно
SET FOREIGN_KEY_CHECKS = 0;

-- 2. ИЗТРИВАНЕ НА СТАРИ ТАБЛИЦИ (в правилен ред, за да не гърмят връзките)
DROP TABLE IF EXISTS match_events;
DROP TABLE IF EXISTS matches;
DROP TABLE IF EXISTS transfers;
DROP TABLE IF EXISTS league_teams;
DROP TABLE IF EXISTS players;
DROP TABLE IF EXISTS clubs;
DROP TABLE IF EXISTS leagues;

-- 3. СЪЗДАВАНЕ НА ТАБЛИЦИТЕ (DDL)

-- Етап 5: Лиги
CREATE TABLE leagues (
    LeagueId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Season VARCHAR(9) NOT NULL, -- Формат: 2025/2026
    UNIQUE(Name, Season)
) ENGINE=InnoDB;

-- Етап 2: Клубове
CREATE TABLE clubs (
    ClubId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL UNIQUE,
    City VARCHAR(100),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- Етап 3: Играчи
CREATE TABLE players (
    PlayerId INT AUTO_INCREMENT PRIMARY KEY,
    ClubId INT NOT NULL,
    FullName VARCHAR(100) NOT NULL,
    BirthDate DATE NOT NULL,
    Position ENUM('GK', 'DF', 'MF', 'FW') NOT NULL,
    ShirtNumber INT,
    FOREIGN KEY (ClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT
) ENGINE=InnoDB;

-- Етап 5: Участници в лигите (Many-to-Many връзка)
CREATE TABLE league_teams (
    LeagueId INT NOT NULL,
    ClubId INT NOT NULL,
    PRIMARY KEY (LeagueId, ClubId),
    FOREIGN KEY (LeagueId) REFERENCES leagues(LeagueId) ON DELETE CASCADE,
    FOREIGN KEY (ClubId) REFERENCES clubs(ClubId) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Етап 4: Трансфери и история
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

-- Етап 1: Мачове
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

-- Етап 1: Събития по време на мач (голове, картони)
CREATE TABLE match_events (
    EventId INT AUTO_INCREMENT PRIMARY KEY,
    MatchId INT NOT NULL,
    PlayerId INT NOT NULL,
    EventType ENUM('Goal', 'Yellow Card', 'Red Card') NOT NULL,
    EventMinute INT,
    FOREIGN KEY (MatchId) REFERENCES matches(MatchId) ON DELETE CASCADE,
    FOREIGN KEY (PlayerId) REFERENCES players(PlayerId) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Пускаме проверките за чужди ключове обратно
SET FOREIGN_KEY_CHECKS = 1;

-- ==========================================
-- 4. ПРИМЕРНИ ДАННИ (SEED DATA) ЗА ТЕСТВАНЕ
-- ==========================================

-- Добавяне на лиги
INSERT INTO leagues (Name, Season) VALUES 
('Първа Лига', '2024/2025'), 
('Втора Лига', '2024/2025');

-- Добавяне на клубове
INSERT INTO clubs (Name, City) VALUES 
('Левски', 'София'), 
('ЦСКА', 'София'), 
('Лудогорец', 'Разград'),
('Черно Море', 'Варна'),
('Ботев', 'Пловдив');

-- Добавяне на играчи
INSERT INTO players (ClubId, FullName, BirthDate, Position, ShirtNumber) VALUES 
(1, 'Марин Петков', '2003-10-02', 'FW', 88),
(1, 'Пламен Андреев', '2004-12-15', 'GK', 1),
(2, 'Тобиас Хайнц', '1998-07-13', 'MF', 14),
(3, 'Бърнард Текпетей', '1997-09-01', 'FW', 37);

-- Добавяне на отбори в "Първа Лига" (LeagueId = 1)
INSERT INTO league_teams (LeagueId, ClubId) VALUES 
(1, 1), -- Левски
(1, 2), -- ЦСКА
(1, 3), -- Лудогорец
(1, 4); -- Черно Море

ALTER TABLE matches ADD COLUMN RoundNo INT NOT NULL AFTER LeagueId;
