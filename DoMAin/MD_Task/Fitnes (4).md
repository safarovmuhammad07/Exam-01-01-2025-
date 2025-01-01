# Практическое задание: Реализация WebAPI с использованием EF Core, Fluent API и Data Annotations

## Цель задания
Создать WebAPI приложение для управления фитнес-центром, используя Entity Framework Core с PostgreSQL, применяя Fluent API и Data Annotations для конфигурации моделей.

## Описание предметной области
Необходимо реализовать систему управления фитнес-центром, где есть следующие сущности:
- Тренеры (Trainers)
- Тренировки (Workouts)
- Клиенты (Clients)
- Записи на тренировки (WorkoutSessions)

## Требования к реализации

### 1. Создание моделей данных
Реализуйте следующие модели с указанными требованиями:

#### Trainer
- Id (int, primary key)
- FirstName (string, required, max 50 characters)
- LastName (string, required, max 50 characters)
- PhoneNumber (string, required, валидация формата)
- Experience (int, в годах, больше 0)
- Status (enum TrainerStatus { Active, OnVacation, Suspended, Terminated })
- Specialization (string, max 100 characters)

#### Workout
- Id (int, primary key)
- Name (string, required, max 100 characters)
- Description (string, max 500 characters)
- Duration (int, время в минутах, больше 0)
- MaxParticipants (int, больше 0)
- Difficulty (enum WorkoutDifficulty { Beginner, Intermediate, Advanced, Expert })
- IsActive (bool)

#### Client
- Id (int, primary key)
- FirstName (string, required, max 50 characters)
- LastName (string, required, max 50 characters)
- PhoneNumber (string, required, валидация формата)
- Email (string, валидация формата)
- DateOfBirth (DateTime)
- MembershipStatus (enum MembershipStatus { Active, Inactive, Suspended, Expired })

#### WorkoutSession
- Id (int, primary key)
- TrainerId (foreign key)
- WorkoutId (foreign key)
- ClientId (foreign key)
- SessionDate (DateTime, не в прошлом)
- StartTime (TimeSpan, рабочие часы 7:00-23:00)
- EndTime (TimeSpan, рабочие часы 7:00-23:00)
- Status (enum SessionStatus { Scheduled, InProgress, Completed, Cancelled })
- MaxCapacity (int)
- CurrentParticipants (int)
- Comment (string, max 200 characters)
- CreatedAt (DateTime)

### 2. Задачи по конфигурации

#### Часть 1: Data Annotations
- Использовать Data Annotations для валидации Email и номеров телефонов
- Использовать StringLength для ограничения длины текстовых полей
- Добавить валидацию возраста клиента (больше 16 лет)

#### Часть 2: Fluent API
- Настроить связи один-ко-многим между тренером и сессий тренировками (WorkoutSession)
- Настроить связи один-ко-многим между клиентом и сессий тренировками (WorkoutSession)
- Настроить связи один-ко-многим между тренировками и сессий тренировками (WorkoutSession)
- Настроить каскадное удаление для связанных записей
- Настроить уникальные ограничения для записей

### 3. API Endpoints

#### Trainers
- GET /api/trainers - получение списка тренеров
- GET /api/trainers/{id} - получение информации о конкретном тренере
- POST /api/trainers - добавление нового тренера
- PUT /api/trainers/{id} - обновление информации о тренере
- DELETE /api/trainers/{id} - удаление тренера

#### Workouts
- GET /api/workouts - получение списка тренировок
- GET /api/workouts/{id} - получение информации о конкретной тренировке
- POST /api/workouts - добавление новой тренировки
- PUT /api/workouts/{id} - обновление информации о тренировке
- DELETE /api/workouts/{id} - удаление тренировки

#### Clients
- GET /api/clients - получение списка клиентов
- GET /api/clients/{id} - получение информации о клиенте
- POST /api/clients - регистрация нового клиента
- PUT /api/clients/{id} - обновление информации о клиенте
- DELETE /api/clients/{id} - удаление клиента

#### WorkoutSessions
- GET /api/sessions - получение списка тренировок
- POST /api/sessions - создание новой тренировки
- PUT /api/sessions/{id}/status - обновление статуса тренировки
- DELETE /api/sessions/{id} - отмена тренировки

## Теоретические вопросы для проверки знаний

1. Что такое DbContext и какую роль он играет в Entity Framework Core?
2. В чем разница между Fluent API и Data Annotations? Когда что лучше использовать?
3. Перечислите основные атрибуты Data Annotations и их назначение.
4. Как организовать связь many-to-many в Entity Framework Core?
5. Как настроить внешний ключ через Fluent API?
6. Объясните принцип работы каскадного удаления в Entity Framework Core.
7. Что такое DTO и для чего они используются в веб-приложениях?
8. Что такое навигационные свойства и как они связаны с foreign key?
9. Зачем нужны миграции в Entity Framework Core и как с ними работать?
10. Как настроить каскадное удаление через Fluent API?