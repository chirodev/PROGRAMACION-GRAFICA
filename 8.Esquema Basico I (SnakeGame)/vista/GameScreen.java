package com.mygdx.game.vista;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.ScreenAdapter;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.glutils.ShapeRenderer;

import static com.mygdx.game.Controladores.SnakeController.*;
import static com.mygdx.game.vista.variablesGlobales.*;

public class GameScreen extends ScreenAdapter {


	@Override
	public void show(){
		shapeRenderer=new ShapeRenderer();
		batch=new SpriteBatch();
		snakeHead=new Texture(Gdx.files.internal("snakeHead.png"));
		apple=new Texture(Gdx.files.internal("apple.png"));
		snakeBody=new Texture(Gdx.files.internal("snakeBody.png"));
		bitmapFont = new BitmapFont();
	}

	@Override
	public void render(float delta){
		switch(state){
			case PLAYING: {
				queryInput();
				updateSnake(delta);
				checkAppleCollision();
				checkAndPlaceApple();
			}
			break;
			case GAME_OVER:{

			}
			break;
		}
		clearScreen();
		//drawGrid();
		draw();
	}



	private void clearScreen(){
		Gdx.gl.glClearColor(Color.BLACK.r, Color.BLACK.g, Color.BLACK.b, Color.BLACK.a);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
	}

	private void draw(){
		batch.begin();
		batch.draw(snakeHead, snakeX, snakeY);
		for(BodyPart bodyPart:bodyParts){
			bodyPart.draw(batch);
		}
		if (appleAvailable) {
			batch.draw(apple, appleX, appleY);
		}
		if (state == STATE.GAME_OVER) {
			layout.setText(bitmapFont, GAME_OVER_TEXT);
			bitmapFont.draw(batch, GAME_OVER_TEXT, 300 ,  200 );
		}
		batch.end();
	}

	private void checkAppleCollision(){
		if(appleAvailable && appleX == snakeX && appleY ==snakeY){
			BodyPart bodyPart = new BodyPart(snakeBody);
			bodyPart.updateBodyPosition(snakeX, snakeY);
			bodyParts.insert(0,bodyPart);
			appleAvailable=false;
		}
	}



	private void drawGrid(){
		shapeRenderer.begin(ShapeRenderer.ShapeType.Line);
		for(int x=0;x<Gdx.graphics.getWidth();x+=GRID_CELL){
			for(int y=0;y<Gdx.graphics.getHeight();y+=GRID_CELL){
				shapeRenderer.rect(x, y, GRID_CELL, GRID_CELL);
			}
		}
		shapeRenderer.end();
	}







}
