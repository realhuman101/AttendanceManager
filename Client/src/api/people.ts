import axios from 'axios';
import resolve from './resolve';
import * as data from './config.json';

const url = data.url;
export async function allPeople() {
	return await resolve(axios.get(url+'/api/People', { withCredentials: true }).then(res => res.data));
}

export async function personClass(id: number) {
	return await resolve(axios.get(url+`/api/People/${id}/classes`, { withCredentials: true }).then(res => res.data));
}

export async function specificPerson(id: number) {
	return await resolve(axios.get(url+`/api/People/${id}`, { withCredentials: true }).then(res => res.data));
}

export async function searchPeople(name: string) {
	return await resolve(axios.get(url+`/api/People/search/${name}`, { withCredentials: true }).then(res => res.data));
}

export async function updatePersonStatus(id: number, state: boolean) {
	return await resolve(axios.post(url+`/api/People/${id}&${state}`, { withCredentials: true }).then(res => res.data));
}
