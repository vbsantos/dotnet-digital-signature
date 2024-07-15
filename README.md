# Desafio AVMB - Fullstack Dev

## Descrição

Este projeto é uma aplicação que integra com a plataforma Asten Assinatura, utilizando .NET para o backend. O objetivo é consumir os serviços da API do Asten Assinatura e disponibilizar funcionalidades via API e interface de usuário.

## Funcionalidades

- Criação de envelopes
- Configuração de signatários em envelopes
- Encaminhamento do envelope para assinatura
- Consulta do status de um envelope
- Salvar em banco os dados do envelope e realizar o download do mesmo quando estiver com status concluído
- Disponibilização dos serviços em API Swagger
- Consumo via frontend

## Tecnologias Utilizadas

- .NET (versão LTS)
- Banco de dados (convencionais ou serverless)
- Swagger para documentação da API
- Frontend comunicando com o backend

## Requisitos Obrigatórios

- Disponibilização do código via GitHub em um repositório público
- Backend API REST (servindo de porta de entrada para o frontend)
- Utilização da versão LTS do .NET
- Uso do Swagger para documentação
- Frontend consumindo os endpoints do backend

## Requisitos Opcionais

- Utilização de testes automatizados no backend
- Utilização do Vue 3 para o Frontend
- Implementação de autenticação
