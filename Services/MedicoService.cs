﻿using AutoMapper;
using CitasMedico.DTOs;
using CitasMedico.Exceptions;
using CitasMedico.Models;
using CitasMedico.Repository;

namespace CitasMedico.Services
{
    public class MedicoService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public MedicoService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<MedicoDTO> GetAllMedicos()
        {
            return _mapper.Map<IEnumerable<MedicoDTO>>(_unitOfWork.Medicos.GetAll());
        }

        public MedicoDTO GetMedicoById(int id)
        {
            if (!_unitOfWork.Medicos.Exist(id))
                throw new ServiceException(ErrorType.NotFound, "No existe un médico con ese Id");
            return _mapper.Map<MedicoDTO>(_unitOfWork.Medicos.GetById(id));
        }

        public MedicoDTO CreateMedico(MedicoRequestDTO medico)
        {
            try
            {
                var result = _mapper.Map<MedicoDTO>(_unitOfWork.Medicos.Add(_mapper.Map<MedicoRequestDTO, Medico>(medico)));
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }
        }

        public MedicoDTO DeleteMedicoById(int id)
        {
            if (!_unitOfWork.Medicos.Exist(id))
                throw new ServiceException(ErrorType.NotFound);
            try
            {
                var result = _mapper.Map<MedicoDTO>(_unitOfWork.Medicos.Delete(_unitOfWork.Medicos.GetById(id)));
                _unitOfWork.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Ha ocurrido un error inesperado", ex.InnerException);
            }
        }

        public MedicoDTO UpdateMedico(int id, MedicoRequestDTO medico)
        {
            Medico? Medico = _unitOfWork.Medicos.GetById(id);
            if (Medico == null)
                throw new ServiceException(ErrorType.NotFound, "No hay médico con ese ID");
            if (medico.IdsPaciente != null)
            {
                Medico.Pacientes.Clear();
                foreach (var item in medico.IdsPaciente)
                {
                    Paciente? Paciente = _unitOfWork.Pacientes.GetById(item);
                    if (Paciente == null)
                        throw new ServiceException(ErrorType.NotFound, "No existe el paciente proporcionado");
                    Medico.Pacientes.Add(Paciente);
                }
            }

            Medico.Update(medico);
            try
            {
                _unitOfWork.Medicos.Update(Medico);

                _unitOfWork.SaveChanges();
                return _mapper.Map<MedicoDTO>(Medico);
            }
            catch (Exception ex)
            {
                throw new ServiceException(ErrorType.UnexpectedError, "Error inesperado en el proceso de actualización", ex.InnerException);
            }
        }
    }
}
