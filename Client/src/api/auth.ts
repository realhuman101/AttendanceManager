import axios from 'axios';
import resolve from './resolve';

export async function login(email, pass) {
	return await resolve(axios.post('/login?useCookies=true', { 
		'Email': email, 
		'Password': pass,
		'TwoFactorCode': 'string',
		'TwoFactorRecoveryCode': 'string'
	}).then(res => res.data));
}