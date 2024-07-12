import axios from 'axios';
import resolve from './resolve';
import * as data from './config.json';

const url = data.url;
export async function allClasses() {
	return await resolve(axios.get(url+'/api/Classes', { withCredentials: true }).then(res => res.data));
}

export async function peopleInClass(id: number) {
	return await resolve(axios.get(url+`/api/Classes/${id}/people`, { withCredentials: true }).then(res => res.data));
}

export async function specificClass(id: number) {
	return await resolve(axios.get(url+`/api/Classes/${id}`, { withCredentials: true }).then(res => res.data));
}
