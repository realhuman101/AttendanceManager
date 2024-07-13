import axios from 'axios';
import resolve from './resolve';

import * as data from './config.json';

const url = data.url;

export async function login(email: string, pass: string) {
	return await resolve(axios.post(url+'/login?useCookies=true&useSessionCookies=true', { 
		'Email': email, 
		'Password': pass,
		'TwoFactorCode': 'string',
		'TwoFactorRecoveryCode': 'string'
	}, { withCredentials: true, headers: {"Access-Control-Allow-Origin": "*"}}).then(res => res.data));
}

export async function refresh() {
	return await resolve(axios.post(url+'/refresh', { withCredentials: true, headers: {"Access-Control-Allow-Origin": "*"}}))
}
