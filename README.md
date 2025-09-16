# Core Game

## Genre: Tower Defense 2D

### Levels: 5

- Each level grants the player a certain amount of coins.
- Coins are used to purchase towers.
- Depending on the number of enemies defeated, players will earn extra coins.
- Each level has multiple enemy waves that vary depending on the stage.
- Players can use 2 special skills (randomly rewarded when winning a level).
- After finishing a level, players can earn up to 3 stars and 1–2 special skills.

---

## Account

- Players need to register and log in (username, password).
- Each account stores the number of stars and the number of special skills.

---

# API

## ERD

[View ERD here](https://drive.google.com/file/d/1QWErwvRAp7ydf0tTEtwE2L0nQU6onxNo/view?usp=sharing)

## Features

### Authentication

- **Login / Register**: No role-based authorization required.  
  Only store username (unique) and password.

### Game Information

- **GetPlayerGameInfo(string userId)**  
  Retrieve game information from the `GameInfo` table by `userId`.

- **GetAllPlayerGameInfos()**  
  Retrieve all records from the `GameInfo` table.

- **UpdateGameInfo(string userId, GameInfo info)**  
  Update a player's `GameInfo` based on `userId`.
