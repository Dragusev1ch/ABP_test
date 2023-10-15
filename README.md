# Project Test Readme

## Рекомендації щодо управління тестами

Цей репозиторій містить як вихідний код програми, так і її тести. Для кращого керування цими елементами проекту, рекомендую наступне:
Для зручнослі тести розміщені в гілці develop, щоб за необхідності не виконувати зайві кроки для використання ПЗ
1. Розміщення тестів:
   - Тести повинні розміщуватися окремо від вихідного коду програми.
   - Потрібно винести каталог (папку) для тестів `APB_test.NUNitTest` з папки проекту.
   - Розмістити їх в одному каталозі (папці) 

2. Видалення тестів із папки програми:
   - Тести не повинні бути розміщені в одній папці із вихідним кодом програми.
   - Переконайтесь, що всі тести були виділені в окремий каталог (папку).

3. Додавання тестів до .gitignore:
   - Додайте каталог тестів (папку, в якій вони розміщені) до файлу `.gitignore`, щоб їх не було додано в git репозиторій.

Це допоможе підтримувати порядок і уникнути конфліктів між тестами та програмою. Всі тести все ще можуть зберігатися в git, але окремо від основного вихідного коду.

Дякуємо за розуміння та співпрацю!

Welcome to the testing phase of our project! We are working on a new design and want to test hypotheses using A/B tests. To facilitate this, we need to ensure that our REST API functions correctly. This API consists of two endpoints. This document will guide you through testing the API and its functionality.

## API Overview

The API is a RESTful service with two endpoints. The web application (client) communicates with the API to generate a unique client ID, which is stored between sessions. The client also requests an experiment by adding a `device-token` as a GET parameter. In response, the server provides the experiment details.

### API Endpoints

1. **Generate a Client ID:**
   - **Type**: GET
   - **Parameters**: None
   - **Return**: A unique client ID.

2. **Request an Experiment:**
   - **Type**: GET
   - **Parameters**: "device-token"
   - **Return**: Experiment details in JSON format.

## Experiments

We have two hypotheses to test using this API.

### Experiment 1: Button Color
We hypothesize that the color of the "Buy" button influences conversion rates.

- **Key**: button_color
- **Options**:
  1. #FF0000 → 33.3%
  2. #00FF00 → 33.3%
  3. #0000FF → 33.3%

### Experiment 2: Price
We hypothesize that changing the purchase price in the app may affect our profit margin. However, to avoid significant losses, only a small portion of the audience will experience this change.

- **Key**: price
- **Options**:
  1. 10 → 75%
  2. 20 → 10%
  3. 50 → 5%
  4. 5 → 10%

## Requirements and Constraints

1. A device, once assigned a value, should always receive that same value.
2. Experiments are only conducted for new devices. If an experiment is created after the first request from a device, that device should not be aware of the experiment.

## Tasks

1. **API Design and Implementation**: Create a REST API for the project, and ensure it is documented using Swagger or Postman.

2. **Statistics Page** (Choose one):
   - Create a simple table displaying a list of experiments, the total number of devices participating in each experiment, and their distribution among options.
   - Provide statistics in JSON format with a list of experiments, the total number of devices, and their distribution among options.

3. **Database**: Use MS SQL as the database to store information about experiments and their results. Provide the database structure as part of your project.

4. **CRUD Operations**: Use direct queries or stored procedures for CRUD (Create, Read, Update, Delete) operations with the database.

5. **GitHub Repository**: Host your solution on GitHub in an open repository.

## Technologies

You are free to use any technologies and libraries within the .NET framework for this project.

Thank you for participating in the testing of our project! Your feedback and evaluation will help us make informed decisions based on the A/B test results. If you have any questions or need assistance, please reach out to the project team.

Happy testing!
