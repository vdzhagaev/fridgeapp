 FridgeApp 🧊

A self-hostable inventory tracker for your fridge, combined with a cloud-based social network for sharing recipes.

> 🚧 **Project Status: Early Development**  
> The core self-hosted inventory module is currently being built. Cloud features and social network are planned for later milestones.

## ✨ Planned Features

- **Inventory Management** – Track products, quantities, and expiration dates.
- **Shopping Lists** – Auto-generated based on consumption forecasts.
- **Recipes** – Create private recipes or publish them to the community.
- **Social Network** – Follow other cooks, like and comment on public recipes.
- **Grocery Integration** – Order missing ingredients directly from supported stores.

## 🚀 Quick Start (Self-Hosted)

> ⚠️ First alpha release coming soon. For now, you can build and run the project locally.

```bash
# Clone the repository
git clone https://github.com/vdzhagaev/fridgeapp.git
cd fridgeapp

# Run with Docker (once image is available)
docker run -d -p 8080:80 -v fridge-data:/app/data ghcr.io/vdzhagaev/fridgeapp-selfhosted:latest
```

## 📖 Documentation
Full documentation will be available in the [Wiki](https://github.com/vdzhagaev/fridgeapp/wiki) as the project progresses.

## 🛣️ Roadmap
See the detailed [Roadmap](docs/ROADMAP.md) for planned milestones.

## 📄 License
This project is licensed under the MIT License – see the [LICENSE](LICENSE) file for details.
