const API_URL = "/api"

export function GET_PRODUTOS() {
    return {
        url: `${API_URL}/produtos`,
        options: {
            method: "GET",
            headers: {
                'Content-Type': 'Application/json'
            }
        }
    }
}

export function GET_CATEGORIAS(){
    return {
        url: `${API_URL}/categorias`,
        options: {
            method: "GET",
            headers: {
                'Content-Type': 'Application/json'
            }
        }
    }
}