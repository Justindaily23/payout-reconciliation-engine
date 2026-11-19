# Today I Learned (TIL) - Payout Reconciliation Engine

A living log of technical concepts, terminal flags, and commands discovered during development.

---

## Docker & Containers

### 2026-11-11: The `-p` Flag (Port Mapping)
* **Concept:** Maps a port on your local physical machine to an isolated port inside a Docker container.
* **Format:** `-p <HostPort>:<ContainerPort>` (e.g., `-p 5432:5432` maps the PostgreSQL port).
* **Why it matters:** It lets your local C# application code running in VS Code connect directly to a database engine trapped inside a Linux container.

### 2026-11-11: Docker vs. Docker Compose
* **Docker:** Builds and runs a *single* isolated container image using a `Dockerfile`.
* **Docker Compose:** An orchestrator that launches and connects *multiple* containers at once using a single `docker-compose.yml` blueprint file. Run `docker compose up -d` to spin up everything at once.

---

## Linux & Terminal Commands

### 2026-11-11: `mkdir -p` (Parents Flag)
* **Concept:** Automatically creates any missing parent/middle directories in a path string instead of throwing a "No such file or directory" error.
* **Why it matters:** Allows safe generation of nested directories in one go. If the folder already exists, it exits quietly without crashing scripts.

### 2026-11-11: Brace Expansion `{}`
* **Concept:** A terminal feature that multiplies strings inside curly brackets to execute complex actions.
* **Example:** `mkdir -p src/Modules/{Identity,Payouts}/{Domain,Application}` expands mathematically to generate 4 separate structural folders at once.

---

## .NET & C# Architecture

### 2026-11-11: `.sln` (Solution) Files
* **Concept:** A master metadata planner file that groups independent `.csproj` projects together so they can be compiled and debugged as a unified system.
* **VS Code Note:** Natively shows as plain white text because VS Code requires the official **C# Dev Kit** extension to highlight its layout syntax.

### 2026-11-11: `webapi` vs. `classlib` Project Templates
* **`webapi`:** An active executable project with a `Program.cs` file that runs a continuous web server to accept incoming network HTTP endpoints.
* **`classlib` (Class Library):** A passive folder component that compiles into a `.dll` library. It cannot run on its own; it exists solely to store reusable code that active layers reference.
