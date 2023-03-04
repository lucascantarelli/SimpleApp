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
- [ ] Generic Repository

## Simple Database
docker run --name simpledb -p 5432:5432 -v ./database:/var/lib/postgresql/data -e POSTGRES_PASSWORD=1234 -d postgres

### Migrations - Create Inicial Migration
dotnet ef --startup-project ../SimpleApi/ migrations add InicialMigration --context PostgreSqlDbContext
### Migrations - Update Database
dotnet ef --startup-project ../SimpleApi/ database update --context PostgreSqlDbContext
