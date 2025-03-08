import { Injectable, UnauthorizedException } from "@nestjs/common";
import { PassportStrategy } from "@nestjs/passport";
import { ExtractJwt, Strategy } from "passport-jwt";

@Injectable()
export class JwtStrategy extends PassportStrategy(Strategy, 'jwt') {
    constructor() {
        super({
            jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken(),
            ignoreExpiration: false,
            secretOrKey: process.env.JWT_SECRET || "default_secret_key"
        });


    }
  
    async validate(payload: any) {
    
        if (!payload || !payload.email) {
            throw new UnauthorizedException("Invalid token payload.");
        }

        return { email: payload.email }; 
    }
    
}
