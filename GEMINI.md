# How to Run the Project

To run the project with hot reloading enabled for the Angular application, use the following command:

```bash
docker-compose up
```

This command will:
- Build and start the `freightui` (Angular app), `freightapi` (ASP.NET Core API), and `postgres` (PostgreSQL database) services.
- The Angular app (`freightui`) is configured for hot reloading, so changes to its source code will automatically reflect in your browser.
- The Angular app will be accessible at `http://localhost:4200/`.
- The ASP.NET Core API will be accessible at `http://localhost:8080/`.

To stop the running containers, use:

```bash
docker-compose down
```
