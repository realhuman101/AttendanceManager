import {post} from './request';
import {currUser} from './users'

export async function login(email: string, pass: string) {
	return await post('/login?useCookies=true&useSessionCookies=true', {
		"Email": email,
		"Password": pass,
		"TwoFactorCode": "string",
		"TwoFactorRecoveryCode": "string"
	})
}

export async function refresh() {
	return await post('/refresh')
}

export async function logout() {
	return await post('/api/Users/Current/LogOut')
}

export async function checkLogIn() : Promise<boolean | null> {
	const user = await currUser();
	
	// Check if user is actually logged in
	if (user.status >= 200 && user.status < 300) 
		return true;
	else if (user.status == 404)
		return false;
	else
		return null;
}
