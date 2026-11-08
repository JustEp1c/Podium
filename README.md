# Podium

Учебный проект по курсу **[«CQRS, Clean Architecture и DDD»](https://stepik.org/course/229549)** на платформе Stepik.

**Podium** — платформа для создания и управления топиками (выступлениями): организатор публикует топик, спикер его ведёт, участники присоединяются и обсуждают. В проекте есть роли участников, комментарии и аутентификация.

> **Статус:** каркас решения. Слои и связи между проектами готовы, бизнес-логика добавляется по ходу курса. Доменных моделей, базы данных и рабочих эндпоинтов пока нет — это следующие шаги.

## Зачем этот репозиторий

Это не готовый продукт, а рабочая тетрадь по курсу: здесь я повторяю материал уроков и складываю результат в чистую архитектуру. Имя **Podium** — собственное название проекта; имена слоёв и пространства имён (`API`, `Application`, `Domain`, `Infrastructure`, `Shared`) намеренно совпадают с курсом, чтобы код из уроков подключался без правок.

## Стек

| Что | Версия |
|---|---|
| .NET | 10.0 (`net10.0`) |
| Entity Framework Core (SQLite) | 10.0.14 |
| ASP.NET Core Identity + JWT | 10.0.14 |
| MediatR | 12.5.0 |
| AutoMapper | 14.0.0 |

Почему именно такие версии: `Microsoft.*` держим в одном поезде `10.0.14`. А AutoMapper и MediatR — последние версии до перехода на двойную лицензию: начиная с AutoMapper 15 и MediatR 13 библиотеки требуют license key и предупреждают в консоли, для учебного проекта это лишний шум.

## Структура решения

Решение — [`Podium.slnx`](Podium.slnx), пять проектов:

| Проект | Слой | Ответственность |
|---|---|---|
| [`Api`](Api/Api.csproj) | Presentation | контроллеры, конфигурация ASP.NET Core, OpenAPI |
| [`Application`](Application/Application.csproj) | Сценарии | команды и запросы, DTO, маппинг |
| [`Domain`](Domain/Domain.csproj) | Ядро | сущности, value objects, бизнес-правила |
| [`Infrastructure`](Infrastructure/Infrastructure.csproj) | Инфраструктура | EF Core, база данных, Identity, внешние сервисы |
| [`Shared`](Shared/Shared.csproj) | Общее | MediatR и общие абстракции |

Зависимости направлены внутрь, к домену:

```text
Api            → Application, Infrastructure
Infrastructure → Application, Domain
Application    → Domain, Shared
Domain         → ни от чего не зависит
Shared         → ни от чего не зависит
```

`Domain` и `Shared` — листья: на них ссылаются, но сами они ни на кого не ссылаются.

## Запуск

Нужен .NET SDK 10.

```powershell
dotnet restore Podium.slnx
dotnet run --project Api
```

Профили запуска — в [`Api/Properties/launchSettings.json`](Api/Properties/launchSettings.json):

- `http` — http://localhost:5194
- `https` — https://localhost:7172 и http://localhost:5194

В режиме Development приложение отдаёт OpenAPI-документ:

```text
http://localhost:5194/openapi/v1.json
```

Это именно JSON-спецификация (`app.MapOpenApi()`); UI вроде Swagger пока не подключён — смотреть удобнее через клиент, например в Postman.

## План по курсу

- [ ] Доменные модели топика и участников, value objects (`TopicId`, `Location`)
- [ ] `DbContext`, конфигурации EF Core и первая миграция SQLite
- [ ] CQRS-обработчики на MediatR и эндпоинты топиков
- [ ] Identity + JWT: регистрация, вход, роли (организатор, спикер, участник)
- [ ] Комментарии, мягкое удаление, централизованная обработка ошибок

## Материалы

- [`assets/together-hub-api.postman_collection.json`](assets/together-hub-api.postman_collection.json) — коллекция запросов к API
- [`assets/snippets/`](assets/snippets) — фрагменты кода из уроков
- Оригинальный шаблон курса: [iksergey/dotnet-together-hub-public](https://github.com/iksergey/dotnet-together-hub-public)
