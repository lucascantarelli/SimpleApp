# Simple App

### Simple Api
- [X] InMemory Database
- [ ] Simple CRUD
- [ ] Simple Validation
- [ ] Simple Error Handling
- [x] Simple Serilog
- [ ] Simple Testing
- [ ] Simple Docker
- [ ] Simple CI/CD
- [ ] Simple Deployment

### Simple Domain
- [ ] Simple Interfaces
- [ ] Simple Entities


### Simple Infra
- [X] Generic Repository
- [X] Simple UnitOfWork
- [X] Simple Migrations
- [X] Simple Sqlite

### Migrations - Create Inicial Migration
dotnet ef --startup-project ../Simple.Api/ migrations add InicialMigration --context SqlServerDbContext
### Migrations - Update Database
dotnet ef --startup-project ../Simple.Api/ database update --context SqlServerDbContext
