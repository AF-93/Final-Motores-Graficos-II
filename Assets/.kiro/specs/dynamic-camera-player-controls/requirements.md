# Requirements Document

## Introduction

Este documento define los requisitos para implementar un sistema de control de jugador dinámico que integre el New Input System de Unity con un sistema de cámaras intercambiables. El sistema permitirá al jugador moverse, saltar, interactuar y cambiar entre dos modos de cámara (Platform y TopDown) con diferentes esquemas de control para cada modo.

## Requirements

### Requirement 1

**User Story:** Como jugador, quiero poder moverme en el juego usando controles intuitivos, para que pueda navegar por el mundo del juego de manera fluida.

#### Acceptance Criteria

1. WHEN el jugador presiona las teclas de movimiento THEN el sistema SHALL mover al personaje en la dirección correspondiente
2. WHEN la cámara está en modo "Platform" THEN el sistema SHALL usar los controles de movimiento de plataforma
3. WHEN la cámara está en modo "TopDown" THEN el sistema SHALL usar los controles de movimiento top-down
4. WHEN no se presiona ninguna tecla de movimiento THEN el personaje SHALL permanecer inmóvil

### Requirement 2

**User Story:** Como jugador, quiero poder saltar cuando esté en modo plataforma, para que pueda superar obstáculos y navegar verticalmente.

#### Acceptance Criteria

1. WHEN el jugador presiona el botón de salto AND la cámara está en modo "Platform" THEN el sistema SHALL ejecutar la acción de salto
2. WHEN el jugador presiona el botón de salto AND la cámara está en modo "TopDown" THEN el sistema SHALL ignorar la acción de salto
3. WHEN el personaje está en el aire THEN el sistema SHALL prevenir saltos adicionales hasta tocar el suelo

### Requirement 3

**User Story:** Como jugador, quiero poder interactuar con objetos en el mundo, para que pueda activar elementos del juego y progresar.

#### Acceptance Criteria

1. WHEN el jugador presiona el botón de interacción THEN el sistema SHALL ejecutar la acción de interacción
2. WHEN hay un objeto interactuable cerca THEN el sistema SHALL permitir la interacción
3. WHEN no hay objetos interactuables cerca THEN el sistema SHALL ignorar la acción de interacción

### Requirement 4

**User Story:** Como jugador, quiero poder cambiar entre modos de cámara, para que pueda experimentar diferentes perspectivas de juego según mis necesidades.

#### Acceptance Criteria

1. WHEN el jugador presiona el botón de cambio de cámara AND la cámara actual es "Platform" THEN el sistema SHALL activar el trigger "TD" en el Animator Controller
2. WHEN el jugador presiona el botón de cambio de cámara AND la cámara actual es "TopDown" THEN el sistema SHALL activar el trigger "Platform" en el Animator Controller
3. WHEN se cambia el modo de cámara THEN el sistema SHALL cambiar automáticamente al Input Action Map correspondiente
4. WHEN se activa el modo "Platform" THEN el sistema SHALL usar el Input Action Map de plataforma
5. WHEN se activa el modo "TopDown" THEN el sistema SHALL usar el Input Action Map top-down

### Requirement 5

**User Story:** Como desarrollador, quiero que el sistema use el New Input System de Unity, para que tenga mejor compatibilidad con diferentes dispositivos de entrada y sea más mantenible.

#### Acceptance Criteria

1. WHEN se inicializa el sistema THEN el sistema SHALL configurar el New Input System con los Action Maps apropiados
2. WHEN se detecta entrada del usuario THEN el sistema SHALL procesar la entrada usando Input Actions
3. WHEN se cambia de modo de cámara THEN el sistema SHALL cambiar automáticamente entre Action Maps
4. IF el Input System no está configurado correctamente THEN el sistema SHALL mostrar errores informativos

### Requirement 6

**User Story:** Como jugador, quiero que los controles respondan de manera diferente según el modo de cámara activo, para que la experiencia de juego sea apropiada para cada perspectiva.

#### Acceptance Criteria

1. WHEN la cámara está en modo "Platform" THEN el movimiento SHALL ser relativo a la orientación de la cámara de plataforma
2. WHEN la cámara está en modo "TopDown" THEN el movimiento SHALL ser relativo a la vista superior
3. WHEN se cambia entre modos THEN la transición de controles SHALL ser inmediata y sin interrupciones
4. WHEN se usa un modo específico THEN solo las acciones relevantes para ese modo SHALL estar activas