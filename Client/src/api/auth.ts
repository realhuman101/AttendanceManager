import {post} from './request';

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
