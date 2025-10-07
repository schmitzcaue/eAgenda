# 📋 Sistema de Gerenciamento: Especificação de Requisitos

Este documento apresenta os **requisitos funcionais e regras de negócio** para os principais módulos do sistema. Cada módulo foi pensado para facilitar o controle e organização de contatos, compromissos, categorias, despesas e tarefas, garantindo eficiência e usabilidade.

---

## 1. Módulo de Contatos

### Funcionalidades
- Inserir novos contatos
- Editar contatos existentes
- Excluir contatos cadastrados
- Visualizar contatos cadastrados

### Regras de Negócio
- Campos obrigatórios:  
  - Nome (2-100 caracteres)  
  - Email (formato válido)  
  - Telefone ((XX) XXXX-XXXX ou (XX) XXXXX-XXXX)  
  - Cargo (opcional)  
  - Empresa (opcional)  
- Não pode haver contatos com o mesmo email e/ou telefone  
- Exclusão bloqueada se houver compromissos vinculados ao contato

---

## 2. Módulo de Compromissos

### Funcionalidades
- Inserir novos compromissos  
- Editar compromissos existentes  
- Excluir compromissos  
- Visualizar compromissos cadastrados  

### Regras de Negócio
- Campos obrigatórios:  
  - Assunto (2-100 caracteres)  
  - Data de Ocorrência  
  - Hora de Início e Término  
  - Tipo (Remoto ou Presencial)  
  - Local (para presencial)  
  - Link (para remoto)  
  - Contato (opcional)  
- Não permitir conflito de horários entre compromissos

---

## 3. Módulo de Categorias

### Funcionalidades
- Cadastrar, editar e excluir categorias  
- Visualizar todas as categorias  
- Visualizar despesas pertencentes a uma categoria  

### Regras de Negócio
- Campos obrigatórios:  
  - Título (2-100 caracteres)  
  - Despesas relacionadas cadastradas posteriormente  
- Títulos devem ser únicos  
- Exclusão não permitida se categoria estiver atrelada a despesas

---

## 4. Módulo de Despesas

### Funcionalidades
- Cadastrar, editar, excluir e visualizar despesas  

### Regras de Negócio
- Campos obrigatórios:  
  - Descrição (2-100 caracteres)  
  - Data de Ocorrência (opcional, padrão é data de cadastro)  
  - Valor (R$)  
  - Forma de Pagamento (À Vista, Crédito ou Débito)  
  - Uma ou mais Categorias  

---

## 5. Módulo de Tarefas

### Funcionalidades
- Cadastrar, editar, excluir e visualizar tarefas  
- Visualizar tarefas pendentes, concluídas e agrupadas por prioridade  

### Regras de Negócio
- Campos obrigatórios:  
  - Título (2-100 caracteres)  
  - Prioridade (Baixa, Normal, Alta)  
  - Datas de criação e conclusão  
  - Status e percentual concluído  
  - Itens de tarefa opcionais

### 5.1 Itens de Tarefas

#### Funcionalidades
- Adicionar/remover itens em uma tarefa  
- Concluir itens, atualizando o percentual da tarefa  

#### Regras de Negócio
- Campos obrigatórios:  
  - Título (2-100 caracteres)  
  - Status de Conclusão  
  - Referência à tarefa pai

---

# 🚀 Vamos construir um sistema organizado, eficiente e fácil de usar!  
Este guia ajudará a entregar uma solução completa para o gerenciamento diário, assegurando qualidade, consistência e excelente experiência para o usuário.

---

## Autor SCHMITZ.CAUE
![](https://imgur.com/IlLOIQD.gif)

  <p>
    <a href="https://www.linkedin.com/in/cau%C3%AA-schmitz-316261356/">
      <img src="https://skillicons.dev/icons?i=linkedin&theme=dark" width="50"/>
      LinkedIn
    </a> &nbsp;  |  &nbsp;
    <a href=https://github.com/schmitzcaue
      <img src="https://skillicons.dev/icons?i=github&theme=dark" width="50"/>
      GitHub
    </a>
  </p>
</main>

## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=cs,dotnet,visualstudio,git,github)](https://skillicons.dev)
