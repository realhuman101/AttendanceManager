import {post} from './request';

export async function login(email: string, pass: string) {
	return await post('/login', {
		"Email": email,
		"Password": pass
	})
}

export async function refresh() {
	return await post('/refresh')
}
