import axios from 'axios';
import resolve from './resolve';
import * as data from './config.json';

const url = data.url;
export async function allUsers() {
	return await resolve(axios.get(url+'/api/User', { withCredentials: true }).then(res => res.data));
}

export async function addRole(email: string, role: string) {
	return await resolve(axios.post(url+`/api/User/Modify/Roles/Add/${email}&${role}`, { withCredentials: true }).then(res => res.data));
}

export async function removeRole(email: string, role: string) {
	return await resolve(axios.post(url+`/api/User/Modify/Roles/Remove/${email}&${role}`, { withCredentials: true }).then(res => res.data));
}

export async function userRoles(email: string) {
	return await resolve(axios.get(url+`/api/User/Roles/${email}`, { withCredentials: true }).then(res => res.data));
}

export async function currUser() {
	return await resolve(axios.get(url+`/api/User/Current`, { withCredentials: true }).then(res => res.data));
}

export async function currUserRoles() {
	return await resolve(axios.get(url+`/api/User/Roles/Current`, { withCredentials: true }).then(res => res.data));
}
