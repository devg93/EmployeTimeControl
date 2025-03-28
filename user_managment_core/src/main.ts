import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import { DocumentBuilder, SwaggerModule } from '@nestjs/swagger';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);

  
  const config = new DocumentBuilder()
  .setTitle('User API')
  .setDescription('API documentation for User Management')
  .setVersion('1.0')
  .addBearerAuth({ 
      type: 'http', 
      scheme: 'bearer', 
      bearerFormat: 'JWT' 
  }, 'access-token') 
  .build();


  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup('api-docs', app, document);

  await app.listen(3000);
  console.log(`Application is running on: http://localhost:3000/api-docs`);
}
bootstrap();
