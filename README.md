Instruções para rodar o projeto
- necessário usar docker
- entre na raiz do projeto execute o seguinte comando

  ```
   docker-compose up --build
    
  ```
Utilizei efcore para criar o banco de dados com code first, assim que criar o container ele já vai criar o banco e executar as migrações

Para executar uma carga no banco voce pode ir em http://localhost:5000/api/users/import execute um POST.

Endpoints:
  - API => http://localhost:5000/swagger/index.html
  - Web => http://localhost:8080
    - Será exibido uma lista de usuários se você já realizou a carga
    - Você pode exportar a lista para excel
    - Você pode ver um usuário mais detalhadamente
    - Você pode atualizar um usuário (no momemento não coloquei alertas de sucesso para usuário)



