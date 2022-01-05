package com.mygdx.game.Controladores;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;

import com.badlogic.gdx.math.MathUtils;
import com.mygdx.game.vista.BodyPart;

import static com.mygdx.game.vista.variablesGlobales.*;
public class SnakeController  {
    public static void queryInput() {
        boolean lPressed = Gdx.input.isKeyPressed(Input.Keys.LEFT);
        boolean rPressed = Gdx.input.isKeyPressed(Input.Keys.RIGHT);
        boolean uPressed = Gdx.input.isKeyPressed(Input.Keys.UP);
        boolean dPressed = Gdx.input.isKeyPressed(Input.Keys.DOWN);

        if (lPressed) updateDirection(LEFT);
        if (rPressed) updateDirection(RIGHT);
        if (uPressed) updateDirection(UP);
        if (dPressed) updateDirection(DOWN);
    }

    public static void moveSnake(){
        snakeXBeforeUpdate=snakeX;
        snakeYBeforeUpdate=snakeY;
        switch(snakeDirection){
            case RIGHT: {
                snakeX+=SNAKE_MOVEMENT;
                return;
            }
            case LEFT: {
                snakeX-=SNAKE_MOVEMENT;
                return;
            }
            case UP: {
                snakeY+=SNAKE_MOVEMENT;
                return;
            }
            case DOWN: {
                snakeY-=SNAKE_MOVEMENT;
                return;
            }
        }
    }

    public static void updateDirection(int newSnakeDirection) {
        if (!directionSet && snakeDirection != newSnakeDirection) {
            directionSet = true;
            switch (newSnakeDirection) {
                case LEFT: {
                    updateIfNotOppositeDirection(newSnakeDirection, RIGHT);
                }
                break;
                case RIGHT: {
                    updateIfNotOppositeDirection(newSnakeDirection, LEFT);
                }
                break;
                case UP: {
                    updateIfNotOppositeDirection(newSnakeDirection, DOWN);
                }
                break;
                case DOWN: {
                    updateIfNotOppositeDirection(newSnakeDirection, UP);
                }
                break;
            }
        }
    }
    public static void updateIfNotOppositeDirection(int newSnakeDirection, int oppositeDirection) {
        if (snakeDirection != oppositeDirection || bodyParts.size==0) snakeDirection = newSnakeDirection;
    }
    public static void updateSnake(float delta){
        if(!hasHit){
            timer-=delta;
            if(timer<=0){
                timer=MOVE_TIME;
                moveSnake();
                checkForOutOfBounds();
                updateBodyPartsPosition();
                checkSnakeBodyCollision();
                directionSet=false;
            }
        }
    }
    public static void updateBodyPartsPosition(){
        if(bodyParts.size>0){
            BodyPart bodyPart=bodyParts.removeIndex(0);
            bodyPart.updateBodyPosition(snakeXBeforeUpdate,snakeYBeforeUpdate);
            bodyParts.add(bodyPart);
        }
    }
    public static void checkForOutOfBounds(){
        if(snakeX>=Gdx.graphics.getWidth()){
            snakeX=0;
        }
        if(snakeX<0){
            snakeX=Gdx.graphics.getWidth()-SNAKE_MOVEMENT;
        }
        if(snakeY>=Gdx.graphics.getHeight()){
            snakeY=0;
        }
        if(snakeY<0){
            snakeY=Gdx.graphics.getHeight()-SNAKE_MOVEMENT;
        }
    }

    public static void checkAndPlaceApple(){
        if(!appleAvailable){
            do{
                appleX= MathUtils.random(Gdx.graphics.getBackBufferHeight()/SNAKE_MOVEMENT-1)*SNAKE_MOVEMENT;
                appleY=MathUtils.random(Gdx.graphics.getHeight()/SNAKE_MOVEMENT-1)*SNAKE_MOVEMENT;
                appleAvailable=true;
            } while (appleX==snakeX && appleY == snakeY);
        }
    }
    public static void checkSnakeBodyCollision(){
        for(BodyPart bodyPart:bodyParts){
            if(bodyPart.x == snakeX && bodyPart.y==snakeY) state=STATE.GAME_OVER;
        }
    }


}
