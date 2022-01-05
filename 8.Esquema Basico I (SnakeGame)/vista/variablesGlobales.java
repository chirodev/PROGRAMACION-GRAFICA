package com.mygdx.game.vista;

import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.GlyphLayout;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.glutils.ShapeRenderer;
import com.badlogic.gdx.utils.Array;
import com.badlogic.gdx.utils.viewport.Viewport;


public  class variablesGlobales {
    public static SpriteBatch batch;
    public static Texture snakeHead;

    public  static final float MOVE_TIME= 0.2F;
    public static float timer = MOVE_TIME;
    public  static final int SNAKE_MOVEMENT=32;
    public static int snakeX=0, snakeY=0;
    public  static final int RIGHT=0;
    public  static final int LEFT=1;
    public  static final int UP=2;
    public  static final int DOWN=3;

    public static int snakeDirection=RIGHT;

    public static Texture apple;
    public static boolean appleAvailable=false;
    public static int appleX, appleY;

    public static Texture snakeBody;
    public static Array<BodyPart> bodyParts= new Array<BodyPart>();
    public static int snakeXBeforeUpdate=0, snakeYBeforeUpdate=0;

    public static ShapeRenderer shapeRenderer;
    public static final int GRID_CELL=32;

    public static boolean directionSet=false;
    public static boolean hasHit=false;

    public  enum STATE {
        PLAYING, GAME_OVER
    }
    public static STATE state=STATE.PLAYING;

    public static BitmapFont bitmapFont;
    public static GlyphLayout layout = new GlyphLayout();

    public static Viewport viewport;

    public  static final String GAME_OVER_TEXT="Game Over!";
}
