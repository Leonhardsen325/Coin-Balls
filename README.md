# Coin Balls 🎮⚽

Um jogo de puzzle足球 desenvolvido em Unity 2D onde o objetivo é chutar a bola até o gol, coletando moedas no caminho e evitando obstáculos mortais.

## 📖 Sobre o Jogo

**Coin Balls** é um jogo casual de puzzle onde você controla uma bola de futebol que deve alcançar o gol utilizando mecânicas de física 2D. O jogo apresenta múltiplas fases com dificuldade progressiva, sistema de loja para personalização de bolas, e gerenciamento de economia com moedas.

### 🎯 Objetivo
- Chute a bola na direção certa para alcançar o gol
- Colete moedas para ganhar pontos
- Evite obstáculos como serras, espinhos e bombas
- Gerencie seu número limitado de chutes/bolas

## 🎮 Mecânicas de Jogo

### Controles
1. **Clique e arraste para cima/baixo**: Controla o ângulo do chute (0° a 90°)
2. **Clique e arraste para esquerda/direita**: Controla a força do chute
3. **Solte**: Executa o chute

### Sistema de Vidas
- Cada fase começa com **10 bolas** disponíveis
- A bola é perdida quando:
  - Toca em obstáculos mortais (serras, espinhos, bombas)
  - Sai dos limites laterais do cenário
  - Tempo limite se esgota (5-8 segundos dependendo da fase)

### Pontuação
- **Moedas coletadas**: +10 pontos por moeda
- Moedas são salvas permanentemente e podem ser usadas na loja

## 🏗️ Estrutura do Projeto

```
Assets/
├── Scripts/              # Código C# do jogo
│   ├── GameManager.cs          # Gerencia estado do jogo, bolas e vitórias/derrotas
│   ├── BolaControll.cs         # Controle da física e input da bola
│   ├── UIManager.cs            # Interface durante o jogo (pause, win, lose)
│   ├── ScoreManager.cs         # Sistema de pontuação e moedas
│   ├── AudioManager.cs         # Gerenciamento de áudio (música e SFX)
│   ├── LevelManager.cs         # Menu de seleção de fases
│   ├── CameraSegue.cs          # Câmera que segue a bola
│   ├── Loja/                   # Scripts da loja de bolas
│   └── ...                     # Outros scripts auxiliares
├── CENAS/                # Arquivos .unity das cenas
│   ├── MENU_INICIAL.unity      # Tela inicial
│   ├── LEVEL_GAME.unity        # Seleção de fases
│   ├── LOJA_BOLAS.unity        # Loja de personalização
│   ├── Fase1.unity a Fase4.unity  # Fases do jogo
├── Prefabs/              # Prefabs de objetos
│   ├── BolasPrefab/            # Diferentes tipos de bolas
│   ├── BombaR.prefab           # Inimigos bomba
│   ├── Serra.prefab            # Obstáculos serra
│   └── coin.prefab             # Moedas coletáveis
├── ANIMAÇÃO/             # Animators e Animation Clips
├── BACKGROUND/           # Imagens de fundo das fases
├── ICONES/               # UI, botões e sprites diversos
├── ITENS/                # Sprites de elementos do jogo
├── Musicas/              # Trilha sonora
├── SonsFX/               # Efeitos sonoros
└── Resources/Sprites/    # Sprites das bolas (carregados dinamicamente)
```

## 🔧 Scripts Principais

### GameManager
Controla o fluxo principal do jogo:
- Spawn de bolas
- Contagem de bolas restantes
- Detecção de vitória/derrota
- Transição entre cenas

### BolaControll
Gerencia o comportamento da bola:
- Input do mouse para ângulo e força
- Física de movimento (Rigidbody2D)
- Colisões com obstáculos
- Timer de vida da bola

### UIManager
Interface do usuário:
- Painéis de Pause, Win e Game Over
- Botões de navegação
- Display de pontuação e bolas restantes

### ScoreManager
Economia do jogo:
- Armazenamento persistente de moedas (PlayerPrefs)
- Coleta e perda de moedas
- Sistema de compra na loja

### Loja System (BolasShop, CompraBola, Bolas)
- Lista de bolas desbloqueáveis
- Sistema de compra com verificação de saldo
- Seleção de bola ativa
- Persistência de progresso

## 🎨 Assets e Recursos

### Áudio
- **Músicas de fundo**: 4 faixas aleatórias
- **SFX**: 
  - Coleta de moedas
  - Chute da bola
  - Gol/vitória
  - Explosão/morte da bola
  - Explosão de bomba

### Animações
- Nascimento da bola
- Painéis de UI (slide in/out)
- Explosão da bola
- Animação de "falido" (sem dinheiro)
- Rotação de serras

## 🚀 Como Jogar

### Requisitos
- **Unity**: Versão compatível com Unity 2D (recomendado Unity 2017+)
- **Plataforma**: PC/Mobile (com adaptação para touch)

### Passos para Executar
1. Abra o projeto na Unity
2. Carregue a cena `MENU_INICIAL` para começar
3. Ajuste as configurações de build para sua plataforma alvo
4. Build e execute!

### Sequência de Cenas (Build Index)
```
0-3: Fases 1-4
4: LEVEL_GAME (menu de seleção)
5: LOJA_BOLAS
6: MENU_INICIAL
```

## 💡 Dicas de Gameplay

1. **Ângulo é crucial**: Use ângulos mais baixos para distâncias curtas, mais altos para arcos longos
2. **Gerencie suas bolas**: Não gaste todas em uma fase difícil
3. **Colete todas as moedas**: Maximizar pontos ajuda a comprar novas bolas
4. **Observe os padrões**: Serras e obstáculos têm movimentos previsíveis

## 🛠️ Desenvolvimento Futuro

Sugestões de melhorias:
- [ ] Adicionar mais fases
- [ ] Implementar sistema de conquistas
- [ ] Adicionar power-ups
- [ ] Melhorar feedback visual de colisões
- [ ] Implementar leaderboard online
- [ ] Suporte a múltiplos idiomas
- [ ] Otimizar para mobile com controles touch

## 📝 Notas Técnicas

- **Física**: Utiliza Rigidbody2D e Collider2D
- **Persistência**: PlayerPrefs para salvar moedas e progresso
- **Singleton Pattern**: Usado em managers principais (GameManager, ScoreManager, etc.)
- **Scene Management**: SceneManager com eventos de carga
- **UI System**: Canvas com animações via Animator

## 👤 Créditos

Jogo desenvolvido originalmente há mais de 10 anos como projeto pessoal/hobby.

---

**Engine**: Unity  
**Linguagem**: C#  
**Gênero**: Puzzle / Casual  
**Plataforma**: PC/Mobile  

---

*Projeto mantido para fins educacionais e de preservação*