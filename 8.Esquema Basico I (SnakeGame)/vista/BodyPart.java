package com.mygdx.game.vista;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Batch;
public class BodyPart {
    public int x,y;
    public  int snakeX=0, snakeY=0;
    public Texture texture;

    public BodyPart(Texture texture){
        this.texture=texture;
    }

    public void updateBodyPosition(int x, int y){
        this.x=x;
        this.y=y;
    }

    public void draw(Batch batch){
        if(!(x==snakeX && y==snakeY))batch.draw(texture,x,y);
    }

}

