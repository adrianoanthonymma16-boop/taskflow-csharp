# TaskFlow C# — To-Do List CLI

> **From Python to C#** — A task management system migrated from a Python CLI project to a modern .NET 8 solution, demonstrating the transition from dynamic to statically-typed OOP.

---

## 📋 Overview

**TaskFlow** is a terminal-based to-do list application built with **C# 12 / .NET 8**. It supports creating tasks, marking them as completed, and visualizing progress through a built-in **Dashboard** with completion percentage and a progress bar.

This project was originally developed in Python and later **migrated to C#** as a learning exercise to compare language paradigms, type systems, and project structuring between the two ecosystems.

---

## ✨ Features

| Feature | Description |
|---------|-------------|
| **Create tasks** | Add new tasks with description validation (min 5 letters, no digits/punctuation) |
| **List pending tasks** | View all tasks that are not yet completed |
| **Complete tasks** | Mark a task as done — it moves from the pending list to the completed list |
| **List completed tasks** | View all tasks that have been marked as done |
| **List all tasks** | Combined view of both pending and completed tasks with status indicators |
| **Dashboard** | Real-time statistics: total tasks, completed count, pending count, completion percentage, ASCII progress bar, and list of pending items |

---

## 🏗️ Solution Architecture

```
ToDoList.sln
├── Tarefas/                 # Domain model (class library)
│   ├── Tarefas.csproj
│   └── Class1.cs           # Tarefa entity: Description + Concluido flag
│
├── Utilidades/              # Business logic (class library)
│   ├── Utilidades.csproj
│   └── Utilidades.cs       # GerenciadorTarefas: CRUD + Dashboard
│
└── Principal/               # Entry point (console app)
    ├── Principal.csproj
    └── Program.cs           # Interactive menu loop
```

### Project dependencies

```
Principal ──► Utilidades ──► Tarefas
   (exe)         (lib)         (lib)
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Run the application

```bash
git clone https://github.com/adrianoanthonymma16-boop/taskflow-csharp.git
cd taskflow-csharp
dotnet run --project Principal
```

### Build all projects

```bash
dotnet build
```

---

## 🧩 Models

### Tarefa (Task)

```csharp
namespace Tarefas;

public class Tarefa
{
    public string? Descricao { get; set; }   // Task description
    public bool Concluido { get; set; }       // Completion status
}
```

---

## 🎮 Usage

When you run the application, an interactive menu is displayed:

```
╔══════════════════════════╗
║      TO-DO LIST          ║
╚══════════════════════════╝
 1. Criar tarefa
 2. Listar tarefas pendentes
 3. Concluir tarefa
 4. Listar todas as tarefas
 5. Listar tarefas concluídas
 6. Dashboard
 Enter vazio. Sair
```

### Dashboard preview

```
╔══════════════════════════════╗
║         DASHBOARD            ║
╚══════════════════════════════╝

 Total de tarefas: 5
 Concluídas:       2
 Pendentes:        3
 Progresso:        40.0%

 [########------------] 40%

 Pendentes:
   1. Write integration tests
   2. Refactor data access layer
   3. Set up CI/CD pipeline

Pressione qualquer tecla para voltar...
```

---

## 🔄 Migration: Python → C#

This table highlights key differences between the original Python version and the C# port:

| Aspect | Python | C# |
|--------|--------|----|
| **Type system** | Dynamic (duck typing) | Static (strong, nominal) |
| **Project structure** | Flat files + single namespace | Multi-project solution (SOLID) |
| **Encapsulation** | Convention-based (`_private`) | Language-enforced (`private`, `public`) |
| **Null safety** | Runtime `None` checks | Compile-time `string?` with nullable enabled |
| **Build** | Interpreter (no build step) | `dotnet build` with MSBuild |
| **Dependency management** | No external deps | NuGet + `<ProjectReference>` |
| **Entry point** | `if __name__ == '__main__'` | Top-level statements / `Main()` |
| **Primary constructor** | `__init__` | `public class Tarefa()` (C# 12) |

### Key C# concepts used

- **File-scoped namespaces** (`namespace X;` — C# 10+)
- **Primary constructors** (`public class X()` — C# 12)
- **Nullable reference types** (`string?` with `<Nullable>enable</Nullable>`)
- **Target-typed `new`** (`List<Tarefa> list = new();`)
- **Multi-project solution** with class libraries and separate entry point

---

## 🛠️ Technologies

| Technology | Purpose |
|-----------|---------|
| C# 12 / .NET 8 | Language and runtime |
| MSBuild | Build system |
| .csproj / .sln | Project and solution management |
| System.Console | Terminal I/O |

Zero external NuGet packages — pure .NET base class library.

---

## 📁 File Reference

| File | Role |
|------|------|
| `ToDoList.sln` | Solution file linking all projects |
| `Tarefas/Class1.cs` | `Tarefa` domain entity |
| `Utilidades/Utilidades.cs` | `GerenciadorTarefas` — business logic (CRUD + Dashboard) |
| `Principal/Program.cs` | Console entry point with menu loop |

---

## 👨‍💻 Author

Built as a **Python-to-C# migration study** by [adrianoanthonymma16-boop](https://github.com/adrianoanthonymma16-boop).

---

## 📄 License

This project is for study purposes — no explicit license.
